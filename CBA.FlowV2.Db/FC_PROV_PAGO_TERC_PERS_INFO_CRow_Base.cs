// <fileinfo name="FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="FC_PROV_PAGO_TERC_PERS_INFO_CRow"/> that 
	/// represents a record in the <c>FC_PROV_PAGO_TERC_PERS_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FC_PROV_PAGO_TERC_PERS_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _persona_id;
		private string _nombre_completo;
		private decimal _fc_proveedor_id;
		private decimal _porc_comision;
		private bool _porc_comisionNull = true;
		private decimal _porc_asignado;
		private bool _porc_asignadoNull = true;
		private string _activo_codigo;
		private decimal _condicion_pago_id;
		private bool _condicion_pago_idNull = true;
		private decimal _porc_asignado_cuota;
		private bool _porc_asignado_cuotaNull = true;
		private decimal _total_cuotas;
		private bool _total_cuotasNull = true;
		private decimal _nro_cuota;
		private bool _nro_cuotaNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base"/> class.
		/// </summary>
		public FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.FC_PROVEEDOR_ID != original.FC_PROVEEDOR_ID) return true;
			if (this.IsPORC_COMISIONNull != original.IsPORC_COMISIONNull) return true;
			if (!this.IsPORC_COMISIONNull && !original.IsPORC_COMISIONNull)
				if (this.PORC_COMISION != original.PORC_COMISION) return true;
			if (this.IsPORC_ASIGNADONull != original.IsPORC_ASIGNADONull) return true;
			if (!this.IsPORC_ASIGNADONull && !original.IsPORC_ASIGNADONull)
				if (this.PORC_ASIGNADO != original.PORC_ASIGNADO) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			if (this.IsCONDICION_PAGO_IDNull != original.IsCONDICION_PAGO_IDNull) return true;
			if (!this.IsCONDICION_PAGO_IDNull && !original.IsCONDICION_PAGO_IDNull)
				if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.IsPORC_ASIGNADO_CUOTANull != original.IsPORC_ASIGNADO_CUOTANull) return true;
			if (!this.IsPORC_ASIGNADO_CUOTANull && !original.IsPORC_ASIGNADO_CUOTANull)
				if (this.PORC_ASIGNADO_CUOTA != original.PORC_ASIGNADO_CUOTA) return true;
			if (this.IsTOTAL_CUOTASNull != original.IsTOTAL_CUOTASNull) return true;
			if (!this.IsTOTAL_CUOTASNull && !original.IsTOTAL_CUOTASNull)
				if (this.TOTAL_CUOTAS != original.TOTAL_CUOTAS) return true;
			if (this.IsNRO_CUOTANull != original.IsNRO_CUOTANull) return true;
			if (!this.IsNRO_CUOTANull && !original.IsNRO_CUOTANull)
				if (this.NRO_CUOTA != original.NRO_CUOTA) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_COMPLETO</c> column value.</value>
		public string NOMBRE_COMPLETO
		{
			get { return _nombre_completo; }
			set { _nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FC_PROVEEDOR_ID</c> column value.</value>
		public decimal FC_PROVEEDOR_ID
		{
			get { return _fc_proveedor_id; }
			set { _fc_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORC_COMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORC_COMISION</c> column value.</value>
		public decimal PORC_COMISION
		{
			get
			{
				if(IsPORC_COMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porc_comision;
			}
			set
			{
				_porc_comisionNull = false;
				_porc_comision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORC_COMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORC_COMISIONNull
		{
			get { return _porc_comisionNull; }
			set { _porc_comisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORC_ASIGNADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORC_ASIGNADO</c> column value.</value>
		public decimal PORC_ASIGNADO
		{
			get
			{
				if(IsPORC_ASIGNADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porc_asignado;
			}
			set
			{
				_porc_asignadoNull = false;
				_porc_asignado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORC_ASIGNADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORC_ASIGNADONull
		{
			get { return _porc_asignadoNull; }
			set { _porc_asignadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get
			{
				if(IsCONDICION_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_pago_id;
			}
			set
			{
				_condicion_pago_idNull = false;
				_condicion_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_PAGO_IDNull
		{
			get { return _condicion_pago_idNull; }
			set { _condicion_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORC_ASIGNADO_CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORC_ASIGNADO_CUOTA</c> column value.</value>
		public decimal PORC_ASIGNADO_CUOTA
		{
			get
			{
				if(IsPORC_ASIGNADO_CUOTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porc_asignado_cuota;
			}
			set
			{
				_porc_asignado_cuotaNull = false;
				_porc_asignado_cuota = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORC_ASIGNADO_CUOTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORC_ASIGNADO_CUOTANull
		{
			get { return _porc_asignado_cuotaNull; }
			set { _porc_asignado_cuotaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_CUOTAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_CUOTAS</c> column value.</value>
		public decimal TOTAL_CUOTAS
		{
			get
			{
				if(IsTOTAL_CUOTASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_cuotas;
			}
			set
			{
				_total_cuotasNull = false;
				_total_cuotas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_CUOTAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_CUOTASNull
		{
			get { return _total_cuotasNull; }
			set { _total_cuotasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CUOTA</c> column value.</value>
		public decimal NRO_CUOTA
		{
			get
			{
				if(IsNRO_CUOTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_cuota;
			}
			set
			{
				_nro_cuotaNull = false;
				_nro_cuota = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_CUOTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_CUOTANull
		{
			get { return _nro_cuotaNull; }
			set { _nro_cuotaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FC_PROVEEDOR_ID=");
			dynStr.Append(FC_PROVEEDOR_ID);
			dynStr.Append("@CBA@PORC_COMISION=");
			dynStr.Append(IsPORC_COMISIONNull ? (object)"<NULL>" : PORC_COMISION);
			dynStr.Append("@CBA@PORC_ASIGNADO=");
			dynStr.Append(IsPORC_ASIGNADONull ? (object)"<NULL>" : PORC_ASIGNADO);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(IsCONDICION_PAGO_IDNull ? (object)"<NULL>" : CONDICION_PAGO_ID);
			dynStr.Append("@CBA@PORC_ASIGNADO_CUOTA=");
			dynStr.Append(IsPORC_ASIGNADO_CUOTANull ? (object)"<NULL>" : PORC_ASIGNADO_CUOTA);
			dynStr.Append("@CBA@TOTAL_CUOTAS=");
			dynStr.Append(IsTOTAL_CUOTASNull ? (object)"<NULL>" : TOTAL_CUOTAS);
			dynStr.Append("@CBA@NRO_CUOTA=");
			dynStr.Append(IsNRO_CUOTANull ? (object)"<NULL>" : NRO_CUOTA);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			return dynStr.ToString();
		}
	} // End of FC_PROV_PAGO_TERC_PERS_INFO_CRow_Base class
} // End of namespace
