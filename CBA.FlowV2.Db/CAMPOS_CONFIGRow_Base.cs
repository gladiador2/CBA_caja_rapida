// <fileinfo name="CAMPOS_CONFIGRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONFIGRow"/> that 
	/// represents a record in the <c>CAMPOS_CONFIG</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONFIGRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONFIGRow_Base
	{
		private string _id;
		private string _campo_sql;
		private string _campo;
		private string _codigo_sql;
		private string _codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONFIGRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONFIGRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CAMPO_SQL != original.CAMPO_SQL) return true;
			if (this.CAMPO != original.CAMPO) return true;
			if (this.CODIGO_SQL != original.CODIGO_SQL) return true;
			if (this.CODIGO != original.CODIGO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPO_SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_SQL</c> column value.</value>
		public string CAMPO_SQL
		{
			get { return _campo_sql; }
			set { _campo_sql = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO</c> column value.</value>
		public string CAMPO
		{
			get { return _campo; }
			set { _campo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_SQL</c> column value.</value>
		public string CODIGO_SQL
		{
			get { return _codigo_sql; }
			set { _codigo_sql = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CAMPO_SQL=");
			dynStr.Append(CAMPO_SQL);
			dynStr.Append("@CBA@CAMPO=");
			dynStr.Append(CAMPO);
			dynStr.Append("@CBA@CODIGO_SQL=");
			dynStr.Append(CODIGO_SQL);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONFIGRow_Base class
} // End of namespace
