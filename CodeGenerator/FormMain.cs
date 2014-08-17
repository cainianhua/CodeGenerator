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
		/// <param name="e"></param>
		protected override void OnResize( EventArgs e ) {
			base.OnResize( e );

			this.connectButton.Location = new Point( this.Width - this.connectButton.Width - 30, this.connectButton.Location.Y );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtDbServer_Leave( object sender, EventArgs e ) {
			LoadDatabases();
		}

		private void connectButton_Click( object sender, EventArgs e ) {
			string dbServer = txtDbServer.Text.Trim();
			string dbName = dbComboBox.SelectedValue.ToString();
			List<TableVO> userTables = TableBO.GetInstance( dbServer, dbName ).GetTables();
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

			ColumnBO currBO = ColumnBO.GetInstance( dbServer, dbName );

			foreach ( DataGridViewRow item in dataGridView1.Rows ) {
				if ( !item.Selected ) continue;

				TableVO currVO = (TableVO)item.DataBoundItem;
				if ( currVO != null ) {
					currVO.Columns = currBO.GetColumns( currVO.Name );
					currVO.PKs = currBO.GetPKs( currVO.Name );
					currVO.FKs = currBO.GetFKs( currVO.Name );
					currVO.UKs = currBO.GetUKs( currVO.Name );

					GenerateCodes( currVO );
				}
			}
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
		private void BindDataToDatabaseCombo(DataSet databases) {
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

		private void GenerateCodes( TableVO currVO ) {
			string dirFormatterVO = "Generators\\Codes\\VO\\{0}.cs";
			string dirFormatterDAO = "Generators\\Codes\\DAO\\SqlServer\\{0}.cs";
			string dirFormatterBO = "Generators\\Codes\\BO\\{0}.cs";
			
			// generationg VO.
			using ( StreamReader sr = new StreamReader( "templates\\VO.cshtml", true ) ) {
				string output = Razor.Parse<TableVO>( sr.ReadToEnd(), currVO );
				SaveToFile( string.Format( dirFormatterVO, currVO.Name ), output );
			}
			// generating DAO
			using ( StreamReader sr = new StreamReader( "templates\\DAO.cshtml", true ) ) {
				string output = Razor.Parse<TableVO>( sr.ReadToEnd(), currVO );
				SaveToFile( string.Format( dirFormatterDAO, currVO.Name ), output );
			}
			// generating BO
			using ( StreamReader sr = new StreamReader( "templates\\BO.cshtml", true ) ) {
				string output = Razor.Parse<TableVO>( sr.ReadToEnd(), currVO );
				SaveToFile( string.Format( dirFormatterBO, currVO.Name ), output );
			}
		}
		#endregion
	}
}
