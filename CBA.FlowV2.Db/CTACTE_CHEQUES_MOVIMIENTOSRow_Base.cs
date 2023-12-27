// <fileinfo name="CTACTE_CHEQUES_MOVIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> that 
	/// represents a record in the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_MOVIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private System.DateTime _fecha_movimiento;
		private bool _fecha_movimientoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _estado_original_id;
		private bool _estado_original_idNull = true;
		private decimal _estado_destino_id;
		private bool _estado_destino_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _observacion;
		private decimal _ctacte_cheque_girado_id;
		private bool _ctacte_cheque_girado_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow_Base"/> class.
		/// </summary>
		public CTACTE_CHEQUES_MOVIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHEQUES_MOVIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsFECHA_MOVIMIENTONull != original.IsFECHA_MOVIMIENTONull) return true;
			if (!this.IsFECHA_MOVIMIENTONull && !original.IsFECHA_MOVIMIENTONull)
				if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsESTADO_ORIGINAL_IDNull != original.IsESTADO_ORIGINAL_IDNull) return true;
			if (!this.IsESTADO_ORIGINAL_IDNull && !original.IsESTADO_ORIGINAL_IDNull)
				if (this.ESTADO_ORIGINAL_ID != original.ESTADO_ORIGINAL_ID) return true;
			if (this.IsESTADO_DESTINO_IDNull != original.IsESTADO_DESTINO_IDNull) return true;
			if (!this.IsESTADO_DESTINO_IDNull && !original.IsESTADO_DESTINO_IDNull)
				if (this.ESTADO_DESTINO_ID != original.ESTADO_DESTINO_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_CHEQUE_GIRADO_IDNull != original.IsCTACTE_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_GIRADO_IDNull && !original.IsCTACTE_CHEQUE_GIRADO_IDNull)
				if (this.CTACTE_CHEQUE_GIRADO_ID != original.CTACTE_CHEQUE_GIRADO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			
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
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(IsFECHA_MOVIMIENTONull ? (object)"<NULL>" : FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@ESTADO_ORIGINAL_ID=");
			dynStr.Append(IsESTADO_ORIGINAL_IDNull ? (object)"<NULL>" : ESTADO_ORIGINAL_ID);
			dynStr.Append("@CBA@ESTADO_DESTINO_ID=");
			dynStr.Append(IsESTADO_DESTINO_IDNull ? (object)"<NULL>" : ESTADO_DESTINO_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHEQUES_MOVIMIENTOSRow_Base class
} // End of namespace
