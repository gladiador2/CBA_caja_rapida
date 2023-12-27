// <fileinfo name="CTACTE_BANCOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCOSRow"/> that 
	/// represents a record in the <c>CTACTE_BANCOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_BANCOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCOSRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _reporte_planilla_cheques_id;
		private bool _reporte_planilla_cheques_idNull = true;
		private string _razon_social;
		private string _abreviatura;
		private string _codigo;
		private decimal _pais_id;
		private string _direccion;
		private string _telefono1;
		private string _telefono2;
		private string _telefono3;
		private string _email1;
		private string _email2;
		private string _agente_cuenta_nombre;
		private string _agente_cuenta_telefono1;
		private string _agente_cuenta_telefono2;
		private string _agente_cuenta_telefono3;
		private string _estado;
		private string _es_nacional;
		private string _es_extranjero;
		private decimal _reporte_txt_modelo_id;
		private bool _reporte_txt_modelo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCOSRow_Base"/> class.
		/// </summary>
		public CTACTE_BANCOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_BANCOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsREPORTE_PLANILLA_CHEQUES_IDNull != original.IsREPORTE_PLANILLA_CHEQUES_IDNull) return true;
			if (!this.IsREPORTE_PLANILLA_CHEQUES_IDNull && !original.IsREPORTE_PLANILLA_CHEQUES_IDNull)
				if (this.REPORTE_PLANILLA_CHEQUES_ID != original.REPORTE_PLANILLA_CHEQUES_ID) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.DIRECCION != original.DIRECCION) return true;
			if (this.TELEFONO1 != original.TELEFONO1) return true;
			if (this.TELEFONO2 != original.TELEFONO2) return true;
			if (this.TELEFONO3 != original.TELEFONO3) return true;
			if (this.EMAIL1 != original.EMAIL1) return true;
			if (this.EMAIL2 != original.EMAIL2) return true;
			if (this.AGENTE_CUENTA_NOMBRE != original.AGENTE_CUENTA_NOMBRE) return true;
			if (this.AGENTE_CUENTA_TELEFONO1 != original.AGENTE_CUENTA_TELEFONO1) return true;
			if (this.AGENTE_CUENTA_TELEFONO2 != original.AGENTE_CUENTA_TELEFONO2) return true;
			if (this.AGENTE_CUENTA_TELEFONO3 != original.AGENTE_CUENTA_TELEFONO3) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ES_NACIONAL != original.ES_NACIONAL) return true;
			if (this.ES_EXTRANJERO != original.ES_EXTRANJERO) return true;
			if (this.IsREPORTE_TXT_MODELO_IDNull != original.IsREPORTE_TXT_MODELO_IDNull) return true;
			if (!this.IsREPORTE_TXT_MODELO_IDNull && !original.IsREPORTE_TXT_MODELO_IDNull)
				if (this.REPORTE_TXT_MODELO_ID != original.REPORTE_TXT_MODELO_ID) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</value>
		public decimal REPORTE_PLANILLA_CHEQUES_ID
		{
			get
			{
				if(IsREPORTE_PLANILLA_CHEQUES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_planilla_cheques_id;
			}
			set
			{
				_reporte_planilla_cheques_idNull = false;
				_reporte_planilla_cheques_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_PLANILLA_CHEQUES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_PLANILLA_CHEQUES_IDNull
		{
			get { return _reporte_planilla_cheques_idNull; }
			set { _reporte_planilla_cheques_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
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
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION</c> column value.</value>
		public string DIRECCION
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO1</c> column value.</value>
		public string TELEFONO1
		{
			get { return _telefono1; }
			set { _telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO2</c> column value.</value>
		public string TELEFONO2
		{
			get { return _telefono2; }
			set { _telefono2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO3</c> column value.</value>
		public string TELEFONO3
		{
			get { return _telefono3; }
			set { _telefono3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL1</c> column value.</value>
		public string EMAIL1
		{
			get { return _email1; }
			set { _email1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL2</c> column value.</value>
		public string EMAIL2
		{
			get { return _email2; }
			set { _email2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENTE_CUENTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENTE_CUENTA_NOMBRE</c> column value.</value>
		public string AGENTE_CUENTA_NOMBRE
		{
			get { return _agente_cuenta_nombre; }
			set { _agente_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENTE_CUENTA_TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENTE_CUENTA_TELEFONO1</c> column value.</value>
		public string AGENTE_CUENTA_TELEFONO1
		{
			get { return _agente_cuenta_telefono1; }
			set { _agente_cuenta_telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENTE_CUENTA_TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENTE_CUENTA_TELEFONO2</c> column value.</value>
		public string AGENTE_CUENTA_TELEFONO2
		{
			get { return _agente_cuenta_telefono2; }
			set { _agente_cuenta_telefono2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENTE_CUENTA_TELEFONO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENTE_CUENTA_TELEFONO3</c> column value.</value>
		public string AGENTE_CUENTA_TELEFONO3
		{
			get { return _agente_cuenta_telefono3; }
			set { _agente_cuenta_telefono3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_NACIONAL</c> column value.
		/// </summary>
		/// <value>The <c>ES_NACIONAL</c> column value.</value>
		public string ES_NACIONAL
		{
			get { return _es_nacional; }
			set { _es_nacional = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_EXTRANJERO</c> column value.
		/// </summary>
		/// <value>The <c>ES_EXTRANJERO</c> column value.</value>
		public string ES_EXTRANJERO
		{
			get { return _es_extranjero; }
			set { _es_extranjero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_TXT_MODELO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_TXT_MODELO_ID</c> column value.</value>
		public decimal REPORTE_TXT_MODELO_ID
		{
			get
			{
				if(IsREPORTE_TXT_MODELO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_txt_modelo_id;
			}
			set
			{
				_reporte_txt_modelo_idNull = false;
				_reporte_txt_modelo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_TXT_MODELO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_TXT_MODELO_IDNull
		{
			get { return _reporte_txt_modelo_idNull; }
			set { _reporte_txt_modelo_idNull = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@REPORTE_PLANILLA_CHEQUES_ID=");
			dynStr.Append(IsREPORTE_PLANILLA_CHEQUES_IDNull ? (object)"<NULL>" : REPORTE_PLANILLA_CHEQUES_ID);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@DIRECCION=");
			dynStr.Append(DIRECCION);
			dynStr.Append("@CBA@TELEFONO1=");
			dynStr.Append(TELEFONO1);
			dynStr.Append("@CBA@TELEFONO2=");
			dynStr.Append(TELEFONO2);
			dynStr.Append("@CBA@TELEFONO3=");
			dynStr.Append(TELEFONO3);
			dynStr.Append("@CBA@EMAIL1=");
			dynStr.Append(EMAIL1);
			dynStr.Append("@CBA@EMAIL2=");
			dynStr.Append(EMAIL2);
			dynStr.Append("@CBA@AGENTE_CUENTA_NOMBRE=");
			dynStr.Append(AGENTE_CUENTA_NOMBRE);
			dynStr.Append("@CBA@AGENTE_CUENTA_TELEFONO1=");
			dynStr.Append(AGENTE_CUENTA_TELEFONO1);
			dynStr.Append("@CBA@AGENTE_CUENTA_TELEFONO2=");
			dynStr.Append(AGENTE_CUENTA_TELEFONO2);
			dynStr.Append("@CBA@AGENTE_CUENTA_TELEFONO3=");
			dynStr.Append(AGENTE_CUENTA_TELEFONO3);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ES_NACIONAL=");
			dynStr.Append(ES_NACIONAL);
			dynStr.Append("@CBA@ES_EXTRANJERO=");
			dynStr.Append(ES_EXTRANJERO);
			dynStr.Append("@CBA@REPORTE_TXT_MODELO_ID=");
			dynStr.Append(IsREPORTE_TXT_MODELO_IDNull ? (object)"<NULL>" : REPORTE_TXT_MODELO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_BANCOSRow_Base class
} // End of namespace
