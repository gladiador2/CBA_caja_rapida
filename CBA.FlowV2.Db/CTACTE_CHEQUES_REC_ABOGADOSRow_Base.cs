// <fileinfo name="CTACTE_CHEQUES_REC_ABOGADOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> that 
	/// represents a record in the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_ABOGADOSRow_Base
	{
		private decimal _id;
		private decimal _ctacte_cheque_recibido_id;
		private decimal _abogado_id;
		private System.DateTime _fecha_asignacion;
		private System.DateTime _fecha_desasignacion;
		private bool _fecha_desasignacionNull = true;
		private string _observacion_asignacion;
		private decimal _usuario_asignacion_id;
		private System.DateTime _usuario_asignacion_fecha;
		private decimal _usuario_desasignacion_id;
		private bool _usuario_desasignacion_idNull = true;
		private System.DateTime _usuario_desasignacion_fecha;
		private bool _usuario_desasignacion_fechaNull = true;
		private string _observacion_desasignacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow_Base"/> class.
		/// </summary>
		public CTACTE_CHEQUES_REC_ABOGADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHEQUES_REC_ABOGADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.ABOGADO_ID != original.ABOGADO_ID) return true;
			if (this.FECHA_ASIGNACION != original.FECHA_ASIGNACION) return true;
			if (this.IsFECHA_DESASIGNACIONNull != original.IsFECHA_DESASIGNACIONNull) return true;
			if (!this.IsFECHA_DESASIGNACIONNull && !original.IsFECHA_DESASIGNACIONNull)
				if (this.FECHA_DESASIGNACION != original.FECHA_DESASIGNACION) return true;
			if (this.OBSERVACION_ASIGNACION != original.OBSERVACION_ASIGNACION) return true;
			if (this.USUARIO_ASIGNACION_ID != original.USUARIO_ASIGNACION_ID) return true;
			if (this.USUARIO_ASIGNACION_FECHA != original.USUARIO_ASIGNACION_FECHA) return true;
			if (this.IsUSUARIO_DESASIGNACION_IDNull != original.IsUSUARIO_DESASIGNACION_IDNull) return true;
			if (!this.IsUSUARIO_DESASIGNACION_IDNull && !original.IsUSUARIO_DESASIGNACION_IDNull)
				if (this.USUARIO_DESASIGNACION_ID != original.USUARIO_DESASIGNACION_ID) return true;
			if (this.IsUSUARIO_DESASIGNACION_FECHANull != original.IsUSUARIO_DESASIGNACION_FECHANull) return true;
			if (!this.IsUSUARIO_DESASIGNACION_FECHANull && !original.IsUSUARIO_DESASIGNACION_FECHANull)
				if (this.USUARIO_DESASIGNACION_FECHA != original.USUARIO_DESASIGNACION_FECHA) return true;
			if (this.OBSERVACION_DESASIGNACION != original.OBSERVACION_DESASIGNACION) return true;
			
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
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get { return _ctacte_cheque_recibido_id; }
			set { _ctacte_cheque_recibido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABOGADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ABOGADO_ID</c> column value.</value>
		public decimal ABOGADO_ID
		{
			get { return _abogado_id; }
			set { _abogado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIGNACION</c> column value.</value>
		public System.DateTime FECHA_ASIGNACION
		{
			get { return _fecha_asignacion; }
			set { _fecha_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESASIGNACION</c> column value.</value>
		public System.DateTime FECHA_DESASIGNACION
		{
			get
			{
				if(IsFECHA_DESASIGNACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desasignacion;
			}
			set
			{
				_fecha_desasignacionNull = false;
				_fecha_desasignacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESASIGNACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESASIGNACIONNull
		{
			get { return _fecha_desasignacionNull; }
			set { _fecha_desasignacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_ASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_ASIGNACION</c> column value.</value>
		public string OBSERVACION_ASIGNACION
		{
			get { return _observacion_asignacion; }
			set { _observacion_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION_ID</c> column value.</value>
		public decimal USUARIO_ASIGNACION_ID
		{
			get { return _usuario_asignacion_id; }
			set { _usuario_asignacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION_FECHA</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION_FECHA</c> column value.</value>
		public System.DateTime USUARIO_ASIGNACION_FECHA
		{
			get { return _usuario_asignacion_fecha; }
			set { _usuario_asignacion_fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESASIGNACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESASIGNACION_ID</c> column value.</value>
		public decimal USUARIO_DESASIGNACION_ID
		{
			get
			{
				if(IsUSUARIO_DESASIGNACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desasignacion_id;
			}
			set
			{
				_usuario_desasignacion_idNull = false;
				_usuario_desasignacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESASIGNACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESASIGNACION_IDNull
		{
			get { return _usuario_desasignacion_idNull; }
			set { _usuario_desasignacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESASIGNACION_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESASIGNACION_FECHA</c> column value.</value>
		public System.DateTime USUARIO_DESASIGNACION_FECHA
		{
			get
			{
				if(IsUSUARIO_DESASIGNACION_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desasignacion_fecha;
			}
			set
			{
				_usuario_desasignacion_fechaNull = false;
				_usuario_desasignacion_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESASIGNACION_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESASIGNACION_FECHANull
		{
			get { return _usuario_desasignacion_fechaNull; }
			set { _usuario_desasignacion_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_DESASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_DESASIGNACION</c> column value.</value>
		public string OBSERVACION_DESASIGNACION
		{
			get { return _observacion_desasignacion; }
			set { _observacion_desasignacion = value; }
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
			dynStr.Append(CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@ABOGADO_ID=");
			dynStr.Append(ABOGADO_ID);
			dynStr.Append("@CBA@FECHA_ASIGNACION=");
			dynStr.Append(FECHA_ASIGNACION);
			dynStr.Append("@CBA@FECHA_DESASIGNACION=");
			dynStr.Append(IsFECHA_DESASIGNACIONNull ? (object)"<NULL>" : FECHA_DESASIGNACION);
			dynStr.Append("@CBA@OBSERVACION_ASIGNACION=");
			dynStr.Append(OBSERVACION_ASIGNACION);
			dynStr.Append("@CBA@USUARIO_ASIGNACION_ID=");
			dynStr.Append(USUARIO_ASIGNACION_ID);
			dynStr.Append("@CBA@USUARIO_ASIGNACION_FECHA=");
			dynStr.Append(USUARIO_ASIGNACION_FECHA);
			dynStr.Append("@CBA@USUARIO_DESASIGNACION_ID=");
			dynStr.Append(IsUSUARIO_DESASIGNACION_IDNull ? (object)"<NULL>" : USUARIO_DESASIGNACION_ID);
			dynStr.Append("@CBA@USUARIO_DESASIGNACION_FECHA=");
			dynStr.Append(IsUSUARIO_DESASIGNACION_FECHANull ? (object)"<NULL>" : USUARIO_DESASIGNACION_FECHA);
			dynStr.Append("@CBA@OBSERVACION_DESASIGNACION=");
			dynStr.Append(OBSERVACION_DESASIGNACION);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHEQUES_REC_ABOGADOSRow_Base class
} // End of namespace
