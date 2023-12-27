// <fileinfo name="CTACTE_CHQ_MOV_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_CHQ_MOV_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHQ_MOV_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _ctacte_cheque_girado_id;
		private bool _ctacte_cheque_girado_idNull = true;
		private decimal _estado_original_id;
		private bool _estado_original_idNull = true;
		private string _estado_origen_nombre;
		private string _estado_origen_alias;
		private decimal _estado_destino_id;
		private bool _estado_destino_idNull = true;
		private string _estado_destino_nombre;
		private string _estado_destino_alias;
		private System.DateTime _fecha_movimiento;
		private bool _fecha_movimientoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _usuario_nombre;
		private decimal _cheque_recibido_persona;
		private bool _cheque_recibido_personaNull = true;
		private decimal _cheque_recibido_proveedor;
		private bool _cheque_recibido_proveedorNull = true;
		private decimal _cheque_girado_persona;
		private bool _cheque_girado_personaNull = true;
		private decimal _cheque_girado_proveedor;
		private bool _cheque_girado_proveedorNull = true;
		private decimal _cheque_recibido_entidad;
		private bool _cheque_recibido_entidadNull = true;
		private decimal _cheque_girado_entidad;
		private bool _cheque_girado_entidadNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_CHQ_MOV_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHQ_MOV_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCTACTE_CHEQUE_GIRADO_IDNull != original.IsCTACTE_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_GIRADO_IDNull && !original.IsCTACTE_CHEQUE_GIRADO_IDNull)
				if (this.CTACTE_CHEQUE_GIRADO_ID != original.CTACTE_CHEQUE_GIRADO_ID) return true;
			if (this.IsESTADO_ORIGINAL_IDNull != original.IsESTADO_ORIGINAL_IDNull) return true;
			if (!this.IsESTADO_ORIGINAL_IDNull && !original.IsESTADO_ORIGINAL_IDNull)
				if (this.ESTADO_ORIGINAL_ID != original.ESTADO_ORIGINAL_ID) return true;
			if (this.ESTADO_ORIGEN_NOMBRE != original.ESTADO_ORIGEN_NOMBRE) return true;
			if (this.ESTADO_ORIGEN_ALIAS != original.ESTADO_ORIGEN_ALIAS) return true;
			if (this.IsESTADO_DESTINO_IDNull != original.IsESTADO_DESTINO_IDNull) return true;
			if (!this.IsESTADO_DESTINO_IDNull && !original.IsESTADO_DESTINO_IDNull)
				if (this.ESTADO_DESTINO_ID != original.ESTADO_DESTINO_ID) return true;
			if (this.ESTADO_DESTINO_NOMBRE != original.ESTADO_DESTINO_NOMBRE) return true;
			if (this.ESTADO_DESTINO_ALIAS != original.ESTADO_DESTINO_ALIAS) return true;
			if (this.IsFECHA_MOVIMIENTONull != original.IsFECHA_MOVIMIENTONull) return true;
			if (!this.IsFECHA_MOVIMIENTONull && !original.IsFECHA_MOVIMIENTONull)
				if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.IsCHEQUE_RECIBIDO_PERSONANull != original.IsCHEQUE_RECIBIDO_PERSONANull) return true;
			if (!this.IsCHEQUE_RECIBIDO_PERSONANull && !original.IsCHEQUE_RECIBIDO_PERSONANull)
				if (this.CHEQUE_RECIBIDO_PERSONA != original.CHEQUE_RECIBIDO_PERSONA) return true;
			if (this.IsCHEQUE_RECIBIDO_PROVEEDORNull != original.IsCHEQUE_RECIBIDO_PROVEEDORNull) return true;
			if (!this.IsCHEQUE_RECIBIDO_PROVEEDORNull && !original.IsCHEQUE_RECIBIDO_PROVEEDORNull)
				if (this.CHEQUE_RECIBIDO_PROVEEDOR != original.CHEQUE_RECIBIDO_PROVEEDOR) return true;
			if (this.IsCHEQUE_GIRADO_PERSONANull != original.IsCHEQUE_GIRADO_PERSONANull) return true;
			if (!this.IsCHEQUE_GIRADO_PERSONANull && !original.IsCHEQUE_GIRADO_PERSONANull)
				if (this.CHEQUE_GIRADO_PERSONA != original.CHEQUE_GIRADO_PERSONA) return true;
			if (this.IsCHEQUE_GIRADO_PROVEEDORNull != original.IsCHEQUE_GIRADO_PROVEEDORNull) return true;
			if (!this.IsCHEQUE_GIRADO_PROVEEDORNull && !original.IsCHEQUE_GIRADO_PROVEEDORNull)
				if (this.CHEQUE_GIRADO_PROVEEDOR != original.CHEQUE_GIRADO_PROVEEDOR) return true;
			if (this.IsCHEQUE_RECIBIDO_ENTIDADNull != original.IsCHEQUE_RECIBIDO_ENTIDADNull) return true;
			if (!this.IsCHEQUE_RECIBIDO_ENTIDADNull && !original.IsCHEQUE_RECIBIDO_ENTIDADNull)
				if (this.CHEQUE_RECIBIDO_ENTIDAD != original.CHEQUE_RECIBIDO_ENTIDAD) return true;
			if (this.IsCHEQUE_GIRADO_ENTIDADNull != original.IsCHEQUE_GIRADO_ENTIDADNull) return true;
			if (!this.IsCHEQUE_GIRADO_ENTIDADNull && !original.IsCHEQUE_GIRADO_ENTIDADNull)
				if (this.CHEQUE_GIRADO_ENTIDAD != original.CHEQUE_GIRADO_ENTIDAD) return true;
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
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_recibido_id;
			}
			set
			{
				_ctacte_cheque_recibido_idNull = false;
				_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _ctacte_cheque_recibido_idNull; }
			set { _ctacte_cheque_recibido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_GIRADO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_GIRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_girado_id;
			}
			set
			{
				_ctacte_cheque_girado_idNull = false;
				_ctacte_cheque_girado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_GIRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_GIRADO_IDNull
		{
			get { return _ctacte_cheque_girado_idNull; }
			set { _ctacte_cheque_girado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGINAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGINAL_ID</c> column value.</value>
		public decimal ESTADO_ORIGINAL_ID
		{
			get
			{
				if(IsESTADO_ORIGINAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_original_id;
			}
			set
			{
				_estado_original_idNull = false;
				_estado_original_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_ORIGINAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_ORIGINAL_IDNull
		{
			get { return _estado_original_idNull; }
			set { _estado_original_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_NOMBRE</c> column value.</value>
		public string ESTADO_ORIGEN_NOMBRE
		{
			get { return _estado_origen_nombre; }
			set { _estado_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGEN_ALIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_ALIAS</c> column value.</value>
		public string ESTADO_ORIGEN_ALIAS
		{
			get { return _estado_origen_alias; }
			set { _estado_origen_alias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_ID</c> column value.</value>
		public decimal ESTADO_DESTINO_ID
		{
			get
			{
				if(IsESTADO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_destino_id;
			}
			set
			{
				_estado_destino_idNull = false;
				_estado_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_DESTINO_IDNull
		{
			get { return _estado_destino_idNull; }
			set { _estado_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_NOMBRE</c> column value.</value>
		public string ESTADO_DESTINO_NOMBRE
		{
			get { return _estado_destino_nombre; }
			set { _estado_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_ALIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_ALIAS</c> column value.</value>
		public string ESTADO_DESTINO_ALIAS
		{
			get { return _estado_destino_alias; }
			set { _estado_destino_alias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MOVIMIENTO</c> column value.</value>
		public System.DateTime FECHA_MOVIMIENTO
		{
			get
			{
				if(IsFECHA_MOVIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_movimiento;
			}
			set
			{
				_fecha_movimientoNull = false;
				_fecha_movimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MOVIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MOVIMIENTONull
		{
			get { return _fecha_movimientoNull; }
			set { _fecha_movimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_PERSONA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_PERSONA</c> column value.</value>
		public decimal CHEQUE_RECIBIDO_PERSONA
		{
			get
			{
				if(IsCHEQUE_RECIBIDO_PERSONANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_recibido_persona;
			}
			set
			{
				_cheque_recibido_personaNull = false;
				_cheque_recibido_persona = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_RECIBIDO_PERSONA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_RECIBIDO_PERSONANull
		{
			get { return _cheque_recibido_personaNull; }
			set { _cheque_recibido_personaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_PROVEEDOR</c> column value.</value>
		public decimal CHEQUE_RECIBIDO_PROVEEDOR
		{
			get
			{
				if(IsCHEQUE_RECIBIDO_PROVEEDORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_recibido_proveedor;
			}
			set
			{
				_cheque_recibido_proveedorNull = false;
				_cheque_recibido_proveedor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_RECIBIDO_PROVEEDOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_RECIBIDO_PROVEEDORNull
		{
			get { return _cheque_recibido_proveedorNull; }
			set { _cheque_recibido_proveedorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_GIRADO_PERSONA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_GIRADO_PERSONA</c> column value.</value>
		public decimal CHEQUE_GIRADO_PERSONA
		{
			get
			{
				if(IsCHEQUE_GIRADO_PERSONANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_girado_persona;
			}
			set
			{
				_cheque_girado_personaNull = false;
				_cheque_girado_persona = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_GIRADO_PERSONA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_GIRADO_PERSONANull
		{
			get { return _cheque_girado_personaNull; }
			set { _cheque_girado_personaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_GIRADO_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_GIRADO_PROVEEDOR</c> column value.</value>
		public decimal CHEQUE_GIRADO_PROVEEDOR
		{
			get
			{
				if(IsCHEQUE_GIRADO_PROVEEDORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_girado_proveedor;
			}
			set
			{
				_cheque_girado_proveedorNull = false;
				_cheque_girado_proveedor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_GIRADO_PROVEEDOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_GIRADO_PROVEEDORNull
		{
			get { return _cheque_girado_proveedorNull; }
			set { _cheque_girado_proveedorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_ENTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_ENTIDAD</c> column value.</value>
		public decimal CHEQUE_RECIBIDO_ENTIDAD
		{
			get
			{
				if(IsCHEQUE_RECIBIDO_ENTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_recibido_entidad;
			}
			set
			{
				_cheque_recibido_entidadNull = false;
				_cheque_recibido_entidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_RECIBIDO_ENTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_RECIBIDO_ENTIDADNull
		{
			get { return _cheque_recibido_entidadNull; }
			set { _cheque_recibido_entidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_GIRADO_ENTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_GIRADO_ENTIDAD</c> column value.</value>
		public decimal CHEQUE_GIRADO_ENTIDAD
		{
			get
			{
				if(IsCHEQUE_GIRADO_ENTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_girado_entidad;
			}
			set
			{
				_cheque_girado_entidadNull = false;
				_cheque_girado_entidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_GIRADO_ENTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_GIRADO_ENTIDADNull
		{
			get { return _cheque_girado_entidadNull; }
			set { _cheque_girado_entidadNull = value; }
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
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@ESTADO_ORIGINAL_ID=");
			dynStr.Append(IsESTADO_ORIGINAL_IDNull ? (object)"<NULL>" : ESTADO_ORIGINAL_ID);
			dynStr.Append("@CBA@ESTADO_ORIGEN_NOMBRE=");
			dynStr.Append(ESTADO_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@ESTADO_ORIGEN_ALIAS=");
			dynStr.Append(ESTADO_ORIGEN_ALIAS);
			dynStr.Append("@CBA@ESTADO_DESTINO_ID=");
			dynStr.Append(IsESTADO_DESTINO_IDNull ? (object)"<NULL>" : ESTADO_DESTINO_ID);
			dynStr.Append("@CBA@ESTADO_DESTINO_NOMBRE=");
			dynStr.Append(ESTADO_DESTINO_NOMBRE);
			dynStr.Append("@CBA@ESTADO_DESTINO_ALIAS=");
			dynStr.Append(ESTADO_DESTINO_ALIAS);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(IsFECHA_MOVIMIENTONull ? (object)"<NULL>" : FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_PERSONA=");
			dynStr.Append(IsCHEQUE_RECIBIDO_PERSONANull ? (object)"<NULL>" : CHEQUE_RECIBIDO_PERSONA);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_PROVEEDOR=");
			dynStr.Append(IsCHEQUE_RECIBIDO_PROVEEDORNull ? (object)"<NULL>" : CHEQUE_RECIBIDO_PROVEEDOR);
			dynStr.Append("@CBA@CHEQUE_GIRADO_PERSONA=");
			dynStr.Append(IsCHEQUE_GIRADO_PERSONANull ? (object)"<NULL>" : CHEQUE_GIRADO_PERSONA);
			dynStr.Append("@CBA@CHEQUE_GIRADO_PROVEEDOR=");
			dynStr.Append(IsCHEQUE_GIRADO_PROVEEDORNull ? (object)"<NULL>" : CHEQUE_GIRADO_PROVEEDOR);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_ENTIDAD=");
			dynStr.Append(IsCHEQUE_RECIBIDO_ENTIDADNull ? (object)"<NULL>" : CHEQUE_RECIBIDO_ENTIDAD);
			dynStr.Append("@CBA@CHEQUE_GIRADO_ENTIDAD=");
			dynStr.Append(IsCHEQUE_GIRADO_ENTIDADNull ? (object)"<NULL>" : CHEQUE_GIRADO_ENTIDAD);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHQ_MOV_INFO_COMPLRow_Base class
} // End of namespace
