// <fileinfo name="CAMBIOS_DIVISA_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CAMBIOS_DIVISA_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CAMBIOS_DIVISA_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMBIOS_DIVISA_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMBIOS_DIVISA_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private decimal _ctacte_caja_tesoreria_id;
		private decimal _ctacte_caja_tesoreria_suc_id;
		private string _ctacte_caja_tesoreria_suc_nom;
		private string _ctacte_caja_tesoreria_nombre;
		private string _ctacte_caja_tesoreria_abrev;
		private System.DateTime _fecha;
		private string _nro_comprobante;
		private decimal _total_dolarizado;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _orden_pago_caso_id;
		private bool _orden_pago_caso_idNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMBIOS_DIVISA_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CAMBIOS_DIVISA_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMBIOS_DIVISA_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_SUC_ID != original.CTACTE_CAJA_TESORERIA_SUC_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_SUC_NOM != original.CTACTE_CAJA_TESORERIA_SUC_NOM) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESORERIA_ABREV != original.CTACTE_CAJA_TESORERIA_ABREV) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.TOTAL_DOLARIZADO != original.TOTAL_DOLARIZADO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.IsORDEN_PAGO_CASO_IDNull != original.IsORDEN_PAGO_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_CASO_IDNull && !original.IsORDEN_PAGO_CASO_IDNull)
				if (this.ORDEN_PAGO_CASO_ID != original.ORDEN_PAGO_CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get { return _ctacte_caja_tesoreria_id; }
			set { _ctacte_caja_tesoreria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_SUC_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_SUC_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_SUC_ID
		{
			get { return _ctacte_caja_tesoreria_suc_id; }
			set { _ctacte_caja_tesoreria_suc_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_SUC_NOM</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_SUC_NOM</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_SUC_NOM
		{
			get { return _ctacte_caja_tesoreria_suc_nom; }
			set { _ctacte_caja_tesoreria_suc_nom = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_NOMBRE
		{
			get { return _ctacte_caja_tesoreria_nombre; }
			set { _ctacte_caja_tesoreria_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_ABREV
		{
			get { return _ctacte_caja_tesoreria_abrev; }
			set { _ctacte_caja_tesoreria_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DOLARIZADO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_DOLARIZADO</c> column value.</value>
		public decimal TOTAL_DOLARIZADO
		{
			get { return _total_dolarizado; }
			set { _total_dolarizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_CASO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_CASO_ID
		{
			get
			{
				if(IsORDEN_PAGO_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_caso_id;
			}
			set
			{
				_orden_pago_caso_idNull = false;
				_orden_pago_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_CASO_IDNull
		{
			get { return _orden_pago_caso_idNull; }
			set { _orden_pago_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_SUC_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_SUC_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_SUC_NOM=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_SUC_NOM);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ABREV=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ABREV);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TOTAL_DOLARIZADO=");
			dynStr.Append(TOTAL_DOLARIZADO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CAMBIOS_DIVISA_INFO_COMPLETARow_Base class
} // End of namespace
