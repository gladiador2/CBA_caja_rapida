// <fileinfo name="HISTORICO_PASSWORDRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="HISTORICO_PASSWORDRow"/> that 
	/// represents a record in the <c>HISTORICO_PASSWORD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HISTORICO_PASSWORDRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HISTORICO_PASSWORDRow_Base
	{
		private decimal _usuario_id;
		private string _passwd1;
		private string _passwd2;
		private string _passwd3;
		private string _passwd4;
		private string _passwd5;
		private string _passwd6;

		/// <summary>
		/// Initializes a new instance of the <see cref="HISTORICO_PASSWORDRow_Base"/> class.
		/// </summary>
		public HISTORICO_PASSWORDRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HISTORICO_PASSWORDRow_Base original)
		{
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.PASSWD1 != original.PASSWD1) return true;
			if (this.PASSWD2 != original.PASSWD2) return true;
			if (this.PASSWD3 != original.PASSWD3) return true;
			if (this.PASSWD4 != original.PASSWD4) return true;
			if (this.PASSWD5 != original.PASSWD5) return true;
			if (this.PASSWD6 != original.PASSWD6) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD1</c> column value.</value>
		public string PASSWD1
		{
			get { return _passwd1; }
			set { _passwd1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD2</c> column value.</value>
		public string PASSWD2
		{
			get { return _passwd2; }
			set { _passwd2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD3</c> column value.</value>
		public string PASSWD3
		{
			get { return _passwd3; }
			set { _passwd3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD4</c> column value.</value>
		public string PASSWD4
		{
			get { return _passwd4; }
			set { _passwd4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD5</c> column value.</value>
		public string PASSWD5
		{
			get { return _passwd5; }
			set { _passwd5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASSWD6</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASSWD6</c> column value.</value>
		public string PASSWD6
		{
			get { return _passwd6; }
			set { _passwd6 = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@PASSWD1=");
			dynStr.Append(PASSWD1);
			dynStr.Append("@CBA@PASSWD2=");
			dynStr.Append(PASSWD2);
			dynStr.Append("@CBA@PASSWD3=");
			dynStr.Append(PASSWD3);
			dynStr.Append("@CBA@PASSWD4=");
			dynStr.Append(PASSWD4);
			dynStr.Append("@CBA@PASSWD5=");
			dynStr.Append(PASSWD5);
			dynStr.Append("@CBA@PASSWD6=");
			dynStr.Append(PASSWD6);
			return dynStr.ToString();
		}
	} // End of HISTORICO_PASSWORDRow_Base class
} // End of namespace
