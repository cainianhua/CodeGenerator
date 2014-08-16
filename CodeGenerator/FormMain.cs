using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CodeGenerator
{
	public partial class FormMain : Form
	{
		public FormMain() {
			InitializeComponent();
		}
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

			this.connectButton.Location = new Point( this.Width - 100, this.connectButton.Location.Y );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtDbServer_Leave( object sender, EventArgs e ) {
			LoadDatabases();
		}

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
				this.dbComboBox.ValueMember = "id";
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
	}
}
