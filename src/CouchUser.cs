using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Divan
{
	public class CouchUser : CouchDocument
	{

		public CouchUser(string userName, string password)
		{
			salt= Guid.NewGuid().ToString();
			var sha = SHA1.Create();
			byte[] whatever = Encoding.ASCII.GetBytes(password + salt);
			var tmp = sha.ComputeHash(whatever);
			password_sha = Encoding.UTF8.GetString(tmp);
			name = userName;

			Id = "org.couchdb.user:" + userName;
		}
		
		public string name { get; set;  }
		public string password { get; set; }	
		public string type { get; set; }
		public string salt { get; set; }
		public string password_sha { get; set; }
		public string roles { get { return "[]"; } }
	}
}
