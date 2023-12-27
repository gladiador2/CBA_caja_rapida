// <fileinfo name="TRAMITESRow_Base.cs">
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
	/// The base class for <see cref="TRAMITESRow"/> that 
	/// represents a record in the <c>TRAMITES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITESRow_Base
	{
		private decimal _id;
		private decimal _tramite_tipo_id;
		private decimal _caso_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private decimal _tramite_estado_actual_id;
		private bool _tramite_estado_actual_idNull = true;
		private decimal _sucursal_id;
		private string _titulo;
		private string _observacion;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _caso_originario_id;
		private bool _caso_originario_idNull = true;
		private System.DateTime _fecha;
		private decimal _moneda_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITESRow_Base"/> class.
		/// </summary>
		public TRAMITESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_TIPO_ID != original.TRAMITE_TIPO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsTRAMITE_ESTADO_ACTUAL_IDNull != original.IsTRAMITE_ESTADO_ACTUAL_IDNull) return true;
			if (!this.IsTRAMITE_ESTADO_ACTUAL_IDNull && !original.IsTRAMITE_ESTADO_ACTUAL_IDNull)
				if (this.TRAMITE_ESTADO_ACTUAL_ID != original.TRAMITE_ESTADO_ACTUAL_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsCASO_ORIGINARIO_IDNull != original.IsCASO_ORIGINARIO_IDNull) return true;
			if (!this.IsCASO_ORIGINARIO_IDNull && !original.IsCASO_ORIGINARIO_IDNull)
				if (this.CASO_ORIGINARIO_ID != original.CASO_ORIGINARIO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			
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
		/// Gets or sets the <c>TRAMITE_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ID
		{
			get { return _tramite_tipo_id; }
			set { _tramite_tipo_id = value; }
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
		/// Gets or sets the <c>TRAMITE_ESTADO_ACTUAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_ESTADO_ACTUAL_ID</c> column value.</value>
		public decimal TRAMITE_ESTADO_ACTUAL_ID
		{
			get
			{
				if(IsTRAMITE_ESTADO_ACTUAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_estado_actual_id;
			}
			set
			{
				_tramite_estado_actual_idNull = false;
				_tramite_estado_actual_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_ESTADO_ACTUAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_ESTADO_ACTUAL_IDNull
		{
			get { return _tramite_estado_actual_idNull; }
			set { _tramite_estado_actual_idNull = value; }
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
		/// Gets or sets the <c>TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULO</c> column value.</value>
		public string TITULO
		{
			get { return _titulo; }
			set { _titulo = value; }
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
		/// Gets or sets the <c>CASO_ORIGINARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGINARIO_ID</c> column value.</value>
		public decimal CASO_ORIGINARIO_ID
		{
			get
			{
				if(IsCASO_ORIGINARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_originario_id;
			}
			set
			{
				_caso_originario_idNull = false;
				_caso_originario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGINARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGINARIO_IDNull
		{
			get { return _caso_originario_idNull; }
			set { _caso_originario_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
			dynStr.Append("@CBA@TRAMITE_TIPO_ID=");
			dynStr.Append(TRAMITE_TIPO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TRAMITE_ESTADO_ACTUAL_ID=");
			dynStr.Append(IsTRAMITE_ESTADO_ACTUAL_IDNull ? (object)"<NULL>" : TRAMITE_ESTADO_ACTUAL_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@CASO_ORIGINARIO_ID=");
			dynStr.Append(IsCASO_ORIGINARIO_IDNull ? (object)"<NULL>" : CASO_ORIGINARIO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			return dynStr.ToString();
		}
	} // End of TRAMITESRow_Base class
} // End of namespace
