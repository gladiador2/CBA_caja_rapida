// <fileinfo name="PLANILLA_LIQUIDACIONESRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_LIQUIDACIONESRow"/> that 
	/// represents a record in the <c>PLANILLA_LIQUIDACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_LIQUIDACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_LIQUIDACIONESRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _tipo;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_desde;
		private System.DateTime _fecha_hasta;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _total;
		private string _observacion;
		private decimal _ctactecajatesoreria_id;
		private bool _ctactecajatesoreria_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQUIDACIONESRow_Base"/> class.
		/// </summary>
		public PLANILLA_LIQUIDACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_LIQUIDACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_DESDE != original.FECHA_DESDE) return true;
			if (this.FECHA_HASTA != original.FECHA_HASTA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.TOTAL != original.TOTAL) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTECAJATESORERIA_IDNull != original.IsCTACTECAJATESORERIA_IDNull) return true;
			if (!this.IsCTACTECAJATESORERIA_IDNull && !original.IsCTACTECAJATESORERIA_IDNull)
				if (this.CTACTECAJATESORERIA_ID != original.CTACTECAJATESORERIA_ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_DESDE</c> column value.</value>
		public System.DateTime FECHA_DESDE
		{
			get { return _fecha_desde; }
			set { _fecha_desde = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_HASTA</c> column value.</value>
		public System.DateTime FECHA_HASTA
		{
			get { return _fecha_hasta; }
			set { _fecha_hasta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get { return _total; }
			set { _total = value; }
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
		/// Gets or sets the <c>CTACTECAJATESORERIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTECAJATESORERIA_ID</c> column value.</value>
		public decimal CTACTECAJATESORERIA_ID
		{
			get
			{
				if(IsCTACTECAJATESORERIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctactecajatesoreria_id;
			}
			set
			{
				_ctactecajatesoreria_idNull = false;
				_ctactecajatesoreria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTECAJATESORERIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTECAJATESORERIA_IDNull
		{
			get { return _ctactecajatesoreria_idNull; }
			set { _ctactecajatesoreria_idNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_DESDE=");
			dynStr.Append(FECHA_DESDE);
			dynStr.Append("@CBA@FECHA_HASTA=");
			dynStr.Append(FECHA_HASTA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(TOTAL);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTECAJATESORERIA_ID=");
			dynStr.Append(IsCTACTECAJATESORERIA_IDNull ? (object)"<NULL>" : CTACTECAJATESORERIA_ID);
			return dynStr.ToString();
		}
	} // End of PLANILLA_LIQUIDACIONESRow_Base class
} // End of namespace
