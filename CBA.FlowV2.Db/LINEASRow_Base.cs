// <fileinfo name="LINEASRow_Base.cs">
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
	/// The base class for <see cref="LINEASRow"/> that 
	/// represents a record in the <c>LINEAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LINEASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEASRow_Base
	{
		private decimal _id;
		private string _codigo;
		private string _nombre;
		private string _estado;
		private decimal _agencia_id;
		private bool _agencia_idNull = true;
		private string _edi_path;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _informar;
		private decimal _orden;
		private bool _ordenNull = true;
		private string _bloqueo_activo;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEASRow_Base"/> class.
		/// </summary>
		public LINEASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LINEASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsAGENCIA_IDNull != original.IsAGENCIA_IDNull) return true;
			if (!this.IsAGENCIA_IDNull && !original.IsAGENCIA_IDNull)
				if (this.AGENCIA_ID != original.AGENCIA_ID) return true;
			if (this.EDI_PATH != original.EDI_PATH) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.INFORMAR != original.INFORMAR) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.BLOQUEO_ACTIVO != original.BLOQUEO_ACTIVO) return true;
			
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENCIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENCIA_ID</c> column value.</value>
		public decimal AGENCIA_ID
		{
			get
			{
				if(IsAGENCIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _agencia_id;
			}
			set
			{
				_agencia_idNull = false;
				_agencia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AGENCIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAGENCIA_IDNull
		{
			get { return _agencia_idNull; }
			set { _agencia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI_PATH</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_PATH</c> column value.</value>
		public string EDI_PATH
		{
			get { return _edi_path; }
			set { _edi_path = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INFORMAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INFORMAR</c> column value.</value>
		public string INFORMAR
		{
			get { return _informar; }
			set { _informar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEO_ACTIVO</c> column value.
		/// </summary>
		/// <value>The <c>BLOQUEO_ACTIVO</c> column value.</value>
		public string BLOQUEO_ACTIVO
		{
			get { return _bloqueo_activo; }
			set { _bloqueo_activo = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@AGENCIA_ID=");
			dynStr.Append(IsAGENCIA_IDNull ? (object)"<NULL>" : AGENCIA_ID);
			dynStr.Append("@CBA@EDI_PATH=");
			dynStr.Append(EDI_PATH);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@INFORMAR=");
			dynStr.Append(INFORMAR);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@BLOQUEO_ACTIVO=");
			dynStr.Append(BLOQUEO_ACTIVO);
			return dynStr.ToString();
		}
	} // End of LINEASRow_Base class
} // End of namespace
