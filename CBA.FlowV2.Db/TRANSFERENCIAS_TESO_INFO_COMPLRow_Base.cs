// <fileinfo name="TRANSFERENCIAS_TESO_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> that 
	/// represents a record in the <c>TRANSFERENCIAS_TESO_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIAS_TESO_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado;
		private decimal _entidad_id;
		private string _entidad_nombre;
		private string _entidad_abreviatura;
		private decimal _sucursal_origen_id;
		private string _sucursal_origen_nombre;
		private string _sucursal_origen_abreviatura;
		private decimal _caja_tesoreria_origen_id;
		private string _caja_tesoreria_origen_nombre;
		private decimal _sucursal_destino_id;
		private string _sucursal_destino_nombre;
		private string _sucursal_destino_abreviatura;
		private decimal _caja_tesoreria_destino_id;
		private string _caja_tesoreria_destino_nombre;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _total_dolarizado;
		private bool _total_dolarizadoNull = true;
		private string _observacion;
		private decimal _orden_pago_respalda_caso_id;
		private bool _orden_pago_respalda_caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public TRANSFERENCIAS_TESO_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSFERENCIAS_TESO_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.ENTIDAD_ABREVIATURA != original.ENTIDAD_ABREVIATURA) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_ORIGEN_NOMBRE != original.SUCURSAL_ORIGEN_NOMBRE) return true;
			if (this.SUCURSAL_ORIGEN_ABREVIATURA != original.SUCURSAL_ORIGEN_ABREVIATURA) return true;
			if (this.CAJA_TESORERIA_ORIGEN_ID != original.CAJA_TESORERIA_ORIGEN_ID) return true;
			if (this.CAJA_TESORERIA_ORIGEN_NOMBRE != original.CAJA_TESORERIA_ORIGEN_NOMBRE) return true;
			if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSAL_DESTINO_NOMBRE != original.SUCURSAL_DESTINO_NOMBRE) return true;
			if (this.SUCURSAL_DESTINO_ABREVIATURA != original.SUCURSAL_DESTINO_ABREVIATURA) return true;
			if (this.CAJA_TESORERIA_DESTINO_ID != original.CAJA_TESORERIA_DESTINO_ID) return true;
			if (this.CAJA_TESORERIA_DESTINO_NOMBRE != original.CAJA_TESORERIA_DESTINO_NOMBRE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsTOTAL_DOLARIZADONull != original.IsTOTAL_DOLARIZADONull) return true;
			if (!this.IsTOTAL_DOLARIZADONull && !original.IsTOTAL_DOLARIZADONull)
				if (this.TOTAL_DOLARIZADO != original.TOTAL_DOLARIZADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsORDEN_PAGO_RESPALDA_CASO_IDNull != original.IsORDEN_PAGO_RESPALDA_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_RESPALDA_CASO_IDNull && !original.IsORDEN_PAGO_RESPALDA_CASO_IDNull)
				if (this.ORDEN_PAGO_RESPALDA_CASO_ID != original.ORDEN_PAGO_RESPALDA_CASO_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
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
		/// Gets or sets the <c>ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_NOMBRE</c> column value.</value>
		public string ENTIDAD_NOMBRE
		{
			get { return _entidad_nombre; }
			set { _entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ABREVIATURA</c> column value.</value>
		public string ENTIDAD_ABREVIATURA
		{
			get { return _entidad_abreviatura; }
			set { _entidad_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.</value>
		public string SUCURSAL_ORIGEN_NOMBRE
		{
			get { return _sucursal_origen_nombre; }
			set { _sucursal_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ORIGEN_ABREVIATURA
		{
			get { return _sucursal_origen_abreviatura; }
			set { _sucursal_origen_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESORERIA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_TESORERIA_ORIGEN_ID</c> column value.</value>
		public decimal CAJA_TESORERIA_ORIGEN_ID
		{
			get { return _caja_tesoreria_origen_id; }
			set { _caja_tesoreria_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESORERIA_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_TESORERIA_ORIGEN_NOMBRE</c> column value.</value>
		public string CAJA_TESORERIA_ORIGEN_NOMBRE
		{
			get { return _caja_tesoreria_origen_nombre; }
			set { _caja_tesoreria_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get { return _sucursal_destino_id; }
			set { _sucursal_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_NOMBRE</c> column value.</value>
		public string SUCURSAL_DESTINO_NOMBRE
		{
			get { return _sucursal_destino_nombre; }
			set { _sucursal_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_DESTINO_ABREVIATURA
		{
			get { return _sucursal_destino_abreviatura; }
			set { _sucursal_destino_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESORERIA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_TESORERIA_DESTINO_ID</c> column value.</value>
		public decimal CAJA_TESORERIA_DESTINO_ID
		{
			get { return _caja_tesoreria_destino_id; }
			set { _caja_tesoreria_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESORERIA_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_TESORERIA_DESTINO_NOMBRE</c> column value.</value>
		public string CAJA_TESORERIA_DESTINO_NOMBRE
		{
			get { return _caja_tesoreria_destino_nombre; }
			set { _caja_tesoreria_destino_nombre = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DOLARIZADO</c> column value.</value>
		public decimal TOTAL_DOLARIZADO
		{
			get
			{
				if(IsTOTAL_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_dolarizado;
			}
			set
			{
				_total_dolarizadoNull = false;
				_total_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DOLARIZADONull
		{
			get { return _total_dolarizadoNull; }
			set { _total_dolarizadoNull = value; }
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
		/// Gets or sets the <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_RESPALDA_CASO_ID
		{
			get
			{
				if(IsORDEN_PAGO_RESPALDA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_respalda_caso_id;
			}
			set
			{
				_orden_pago_respalda_caso_idNull = false;
				_orden_pago_respalda_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_RESPALDA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_RESPALDA_CASO_IDNull
		{
			get { return _orden_pago_respalda_caso_idNull; }
			set { _orden_pago_respalda_caso_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_ABREVIATURA=");
			dynStr.Append(ENTIDAD_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_NOMBRE=");
			dynStr.Append(SUCURSAL_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ORIGEN_ABREVIATURA);
			dynStr.Append("@CBA@CAJA_TESORERIA_ORIGEN_ID=");
			dynStr.Append(CAJA_TESORERIA_ORIGEN_ID);
			dynStr.Append("@CBA@CAJA_TESORERIA_ORIGEN_NOMBRE=");
			dynStr.Append(CAJA_TESORERIA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_NOMBRE=");
			dynStr.Append(SUCURSAL_DESTINO_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ABREVIATURA=");
			dynStr.Append(SUCURSAL_DESTINO_ABREVIATURA);
			dynStr.Append("@CBA@CAJA_TESORERIA_DESTINO_ID=");
			dynStr.Append(CAJA_TESORERIA_DESTINO_ID);
			dynStr.Append("@CBA@CAJA_TESORERIA_DESTINO_NOMBRE=");
			dynStr.Append(CAJA_TESORERIA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@TOTAL_DOLARIZADO=");
			dynStr.Append(IsTOTAL_DOLARIZADONull ? (object)"<NULL>" : TOTAL_DOLARIZADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ORDEN_PAGO_RESPALDA_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_RESPALDA_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_RESPALDA_CASO_ID);
			return dynStr.ToString();
		}
	} // End of TRANSFERENCIAS_TESO_INFO_COMPLRow_Base class
} // End of namespace
