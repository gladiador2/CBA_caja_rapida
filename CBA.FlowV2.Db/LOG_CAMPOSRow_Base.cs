// <fileinfo name="LOG_CAMPOSRow_Base.cs">
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
	/// The base class for <see cref="LOG_CAMPOSRow"/> that 
	/// represents a record in the <c>LOG_CAMPOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LOG_CAMPOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LOG_CAMPOSRow_Base
	{
		private decimal _id;
		private string _tabla_id;
		private string _campo_id;
		private string _tipo_dato;

		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_CAMPOSRow_Base"/> class.
		/// </summary>
		public LOG_CAMPOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LOG_CAMPOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.CAMPO_ID != original.CAMPO_ID) return true;
			if (this.TIPO_DATO != original.TIPO_DATO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
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
		/// Gets or sets the <c>TIPO_DATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DATO</c> column value.</value>
		public string TIPO_DATO
		{
			get { return _tipo_dato; }
			set { _tipo_dato = value; }
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
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@CAMPO_ID=");
			dynStr.Append(CAMPO_ID);
			dynStr.Append("@CBA@TIPO_DATO=");
			dynStr.Append(TIPO_DATO);
			return dynStr.ToString();
		}
	} // End of LOG_CAMPOSRow_Base class
} // End of namespace
