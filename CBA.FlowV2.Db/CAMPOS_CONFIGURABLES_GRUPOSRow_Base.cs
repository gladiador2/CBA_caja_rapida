// <fileinfo name="CAMPOS_CONFIGURABLES_GRUPOSRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONFIGURABLES_GRUPOSRow"/> that 
	/// represents a record in the <c>CAMPOS_CONFIGURABLES_GRUPOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONFIGURABLES_GRUPOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONFIGURABLES_GRUPOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _tipo_dato_id;
		private decimal _tipo_texto_predefinido_id;
		private bool _tipo_texto_predefinido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGURABLES_GRUPOSRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONFIGURABLES_GRUPOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONFIGURABLES_GRUPOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.TIPO_DATO_ID != original.TIPO_DATO_ID) return true;
			if (this.IsTIPO_TEXTO_PREDEFINIDO_IDNull != original.IsTIPO_TEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTIPO_TEXTO_PREDEFINIDO_IDNull && !original.IsTIPO_TEXTO_PREDEFINIDO_IDNull)
				if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DATO_ID</c> column value.</value>
		public decimal TIPO_DATO_ID
		{
			get { return _tipo_dato_id; }
			set { _tipo_dato_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTIPO_TEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_texto_predefinido_id;
			}
			set
			{
				_tipo_texto_predefinido_idNull = false;
				_tipo_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_TEXTO_PREDEFINIDO_IDNull
		{
			get { return _tipo_texto_predefinido_idNull; }
			set { _tipo_texto_predefinido_idNull = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@TIPO_DATO_ID=");
			dynStr.Append(TIPO_DATO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTIPO_TEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TIPO_TEXTO_PREDEFINIDO_ID);
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONFIGURABLES_GRUPOSRow_Base class
} // End of namespace
