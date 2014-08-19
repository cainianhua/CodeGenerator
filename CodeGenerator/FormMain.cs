using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using CodeGenerator.VO;
using CodeGenerator.BO;
using RazorEngine;
using System.IO;
using CodeGenerator.Models;
using System.Web;

namespace CodeGenerator
{
    public partial class FormMain : FormBase
    {
        public FormMain() {
            InitializeComponent();
        }

        #region Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            LoadDatabases();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDbServer_Leave( object sender, EventArgs e ) {
            LoadDatabases();
        }
        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click( object sender, EventArgs e ) {
            string dbServer = txtDbServer.Text.Trim();
            string dbName = dbComboBox.SelectedValue.ToString();

            List<TableVO> userTables = TableBO.GetInstance( dbServer, dbName ).GetTables();
            if ( userTables.Count > 0 ) {
                generateCodesButton.Enabled = generateSQLButton.Enabled = true;
            }
            dataGridView1.DataSource = userTables;

            PutMessageToStatusStrip( string.Format( "Load tables completed, count is {0}", userTables.Count ) );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateCodesButton_Click( object sender, EventArgs e ) {
            string dbServer = txtDbServer.Text.Trim();
            string dbName = dbComboBox.SelectedValue.ToString();
            string nameSpace = txtNamespace.Text.Trim();

            if ( string.IsNullOrEmpty( nameSpace ) ) {
                MessageBox.Show( "Please fill Namespace first." );
                return;
            }

            PutMessageToStatusStrip( "Generating files..." );

            ColumnBO currBO = ColumnBO.GetInstance( dbServer, dbName );
            TemplateModel model = null;

            foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                if ( !item.Selected ) continue;
                PutMessageToStatusStrip( "Processing line " + ( item.Index + 1 ) );
                TableVO currVO = (TableVO)item.DataBoundItem;
                if ( currVO != null ) {
                    model = new TemplateModel();
                    model.Namespace = nameSpace;
                    model.TableId = currVO.TableId;
                    model.Name = currVO.Name;
                    model.NameS = currVO.NameS;
                    model.Columns = currBO.GetColumns( currVO.Name );
                    model.PKs = currBO.GetPKs( currVO.Name );
                    model.FKs = currBO.GetFKs( currVO.Name );
                    model.UKs = currBO.GetUKs( currVO.Name );

                    this.GenerateCodes( model, dbName );
                }
            }
            if ( model != null ) GenerateBaseCodes( model, dbName );

            PutMessageToStatusStrip( "Codes generated." );
        }

        private void generateSQLButton_Click( object sender, EventArgs e ) {

        }
        #endregion

        #region Privates
        /// <summary>
        /// 
        /// </summary>
        private void LoadDatabases() {
            string serverName = txtDbServer.Text.Trim();
            if ( !string.IsNullOrEmpty( serverName ) ) {
                Task.Factory.StartNew<DataSet>( GetDatabases, serverName ).ContinueWith( t => {
                    if ( t.Exception != null ) return;
                    if ( t.Result != null ) {
                        BindDataToDatabaseCombo( t.Result );
                    }
                    else {
                        PutMessageToStatusStrip( string.Format( "Can't connect to {0}", serverName ) );
                    }
                } );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <returns></returns>
        private DataSet GetDatabases( object serverName ) {
            return Connector.GetInstance().GetDatabases( serverName.ToString() );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        private void BindDataToDatabaseCombo( DataSet databases ) {
            if ( this.dbComboBox.InvokeRequired ) {
                this.Invoke( new Action<DataSet>( BindDataToDatabaseCombo ), databases );
            }
            else {
                this.dbComboBox.DataSource = databases.Tables[0];
                this.dbComboBox.DisplayMember = "name";
                this.dbComboBox.ValueMember = "name";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void PutMessageToStatusStrip( string message ) {
            if ( this.statusStrip1.InvokeRequired ) {
                this.Invoke( new Action<String>( PutMessageToStatusStrip ), message );
            }
            else {
                this.toolStripStatusLabel1.Text = message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        private void SaveToFile( string filePath, string content ) {
            string dirPath = Path.GetDirectoryName( filePath );
            if ( !Directory.Exists( dirPath ) ) {
                DirectoryEx.CycleCreateDirectory( dirPath );
            }
            using ( StreamWriter sw = new StreamWriter( filePath, false, System.Text.Encoding.Unicode ) ) {
                sw.Write( content );
            }
        }
        /// <summary>
        /// 代码生成方法，所有的代码生成都在这里
        /// </summary>
        /// <param name="currVO"></param>
        private void GenerateCodes( TemplateModel currVO, string dbName ) {
            string dirFormatterVO = "Generators\\{1}\\{2}\\Codes\\VO\\{0}VO.cs";
            string dirFormatterDAO = "Generators\\{1}\\{2}\\Codes\\DAO\\SqlServer\\{0}Provider.cs";
            string dirFormatterBO = "Generators\\{1}\\{2}\\Codes\\BO\\{0}BO.cs";
            string dirFormatterInterface = "Generators\\{1}\\{2}\\Codes\\DAO\\I{0}Provider.cs";
            string dirFormatterSQL = "Generators\\{1}\\{2}\\SQLs\\USP_Save_{0}.sql";
            string dateString = DateTime.Now.ToString( "yyyy-MM-dd" );

            // 1.VO.
            using ( StreamReader sr = new StreamReader( "templates\\VO\\VO.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterVO, currVO.NameS, dateString, dbName ), output );
            }
            // 2.DAO
            using ( StreamReader sr = new StreamReader( "templates\\DAO\\DAO.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterDAO, currVO.NameS, dateString, dbName ), output );
            }
            // 3.BO
            using ( StreamReader sr = new StreamReader( "templates\\BO\\BO.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterBO, currVO.NameS, dateString, dbName ), output );
            }
            // 5.Interface.
            using ( StreamReader sr = new StreamReader( "templates\\DAO\\Interface.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterInterface, currVO.NameS, dateString, dbName ), output );
            }
            // 7.SQL
            using ( StreamReader sr = new StreamReader( "templates\\SQL\\Procedure.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterSQL, currVO.NameS, dateString, dbName ), output );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currVO"></param>
        private void GenerateBaseCodes( TemplateModel currVO, string dbName ) {
            string dirFormatterBaseBO = "Generators\\{0}\\{1}\\Codes\\BO\\BaseBO.cs";
            string dirFormatterBaseDAO = "Generators\\{0}\\{1}\\Codes\\DAO\\SqlServer\\ProviderBase.cs";
            string dirFormatterBaseVO = "Generators\\{0}\\{1}\\Codes\\VO\\BaseVO.cs";
            string dirFormatterHelper = "Generators\\{0}\\{1}\\Codes\\DAO\\SqlServer\\SqlHelper.cs";
            string dateString = DateTime.Now.ToString( "yyyy-MM-dd" );

            // 4.Base
            using ( StreamReader sr = new StreamReader( "templates\\BO\\BaseBO.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterBaseBO, dateString, dbName ), output );
            }
            using ( StreamReader sr = new StreamReader( "templates\\DAO\\ProviderBase.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterBaseDAO, dateString, dbName ), output );
            }
            using ( StreamReader sr = new StreamReader( "templates\\VO\\BaseVO.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterBaseVO, dateString, dbName ), output );
            }
            // 6.Helper
            using ( StreamReader sr = new StreamReader( "templates\\DAO\\SqlHelper.cshtml", true ) ) {
                string output = HttpUtility.HtmlDecode( Razor.Parse<TemplateModel>( sr.ReadToEnd(), currVO ) );
                SaveToFile( string.Format( dirFormatterHelper, dateString, dbName ), output );
            }
        }
        #endregion
    }
}
