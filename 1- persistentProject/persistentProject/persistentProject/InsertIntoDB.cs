using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using MySql.Data.MySqlClient;

namespace persistentProject
{

	public sealed class InsertIntoDB : CodeActivity
	{
		// Define an activity input argument of type string
		public InArgument<string> PhoneNumber { get; set; }
		public InArgument<string> Context { get; set; }

		// If your activity returns a value, derive from CodeActivity<TResult>
		// and return the value from the Execute method.
		protected override void Execute(CodeActivityContext context)
		{
			// Obtain the runtime value of the Text input argument
			string contxt = context.GetValue(this.Context);
			string phoneNumber = context.GetValue(this.PhoneNumber);



			string connectionString = "Data Source=sql126.main-hosting.eu; Initial Catalog=u256565172_agl; User ID=u256565172_root; Password=9pz9WU7Du3Ob;";
			MySqlCommand cmd = new MySqlCommand();
			MySqlConnection cn = new MySqlConnection();
			cn.ConnectionString = connectionString;
			cn.Open();

			cmd.Connection = cn;

			cmd.CommandText = "INSERT INTO inbox(phoneNumber, context) VALUES(" + phoneNumber + "," + "'" + contxt + "')";

			

			cmd.ExecuteNonQuery();
			cmd.Clone();

			MySqlCommand cmd2 = new MySqlCommand();
			cmd2.Connection = cn;
			cmd2.CommandText = "UPDATE applications SET state = 5 WHERE phoneNumber = " + phoneNumber;
			cmd2.ExecuteNonQuery();
			cmd2.Clone();

			cn.Close();
		}
	}
}
