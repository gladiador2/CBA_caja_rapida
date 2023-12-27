// <fileinfo name="ENTIDADES_UUIDRow_Base.cs">
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
	/// The base class for <see cref="ENTIDADES_UUIDRow"/> that 
	/// represents a record in the <c>ENTIDADES_UUID</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENTIDADES_UUIDRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENTIDADES_UUIDRow_Base
	{
		private string _uuid;
		private string _tabla_id;
		private decimal _registro_id;
		private string _campo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENTIDADES_UUIDRow_Base"/> class.
		/// </summary>
		public ENTIDADES_UUIDRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENTIDADES_UUIDRow_Base original)
		{
			if (this.UUID != original.UUID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.CAMPO_ID != original.CAMPO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>UUID</c> column value.
		/// </summary>
		/// <value>The <c>UUID</c> column value.</value>
		public string UUID
		{
			get { return _uuid; }
			set { _uuid = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_ID</c> column value.</value>
		public string CAMPO_ID
		{
			get { return _campo_id; }
			set { _campo_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@UUID=");
			dynStr.Append(UUID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			dynStr.Append("@CBA@CAMPO_ID=");
			dynStr.Append(CAMPO_ID);
			return dynStr.ToString();
		}
	} // End of ENTIDADES_UUIDRow_Base class
} // End of namespace
