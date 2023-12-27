// <fileinfo name="ADENDASRow_Base.cs">
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
	/// The base class for <see cref="ADENDASRow"/> that 
	/// represents a record in the <c>ADENDAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ADENDASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ADENDASRow_Base
	{
		private decimal _id;
		private decimal _contrato_id;
		private System.DateTime _fecha;
		private string _texto;
		private string _aprobado;
		private decimal _usuario_creacion_id;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private string _estado;
		private decimal _usuario_anulacion_id;
		private bool _usuario_anulacion_idNull = true;
		private System.DateTime _fecha_anulacion;
		private bool _fecha_anulacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ADENDASRow_Base"/> class.
		/// </summary>
		public ADENDASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ADENDASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CONTRATO_ID != original.CONTRATO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.APROBADO != original.APROBADO) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsUSUARIO_ANULACION_IDNull != original.IsUSUARIO_ANULACION_IDNull) return true;
			if (!this.IsUSUARIO_ANULACION_IDNull && !original.IsUSUARIO_ANULACION_IDNull)
				if (this.USUARIO_ANULACION_ID != original.USUARIO_ANULACION_ID) return true;
			if (this.IsFECHA_ANULACIONNull != original.IsFECHA_ANULACIONNull) return true;
			if (!this.IsFECHA_ANULACIONNull && !original.IsFECHA_ANULACIONNull)
				if (this.FECHA_ANULACION != original.FECHA_ANULACION) return true;
			
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
		/// Gets or sets the <c>CONTRATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTRATO_ID</c> column value.</value>
		public decimal CONTRATO_ID
		{
			get { return _contrato_id; }
			set { _contrato_id = value; }
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
		/// Gets or sets the <c>TEXTO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>APROBADO</c> column value.</value>
		public string APROBADO
		{
			get { return _aprobado; }
			set { _aprobado = value; }
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
		/// Gets or sets the <c>USUARIO_APROBACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROBACION_ID</c> column value.</value>
		public decimal USUARIO_APROBACION_ID
		{
			get
			{
				if(IsUSUARIO_APROBACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprobacion_id;
			}
			set
			{
				_usuario_aprobacion_idNull = false;
				_usuario_aprobacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROBACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROBACION_IDNull
		{
			get { return _usuario_aprobacion_idNull; }
			set { _usuario_aprobacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
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
		/// Gets or sets the <c>USUARIO_ANULACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ANULACION_ID</c> column value.</value>
		public decimal USUARIO_ANULACION_ID
		{
			get
			{
				if(IsUSUARIO_ANULACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_anulacion_id;
			}
			set
			{
				_usuario_anulacion_idNull = false;
				_usuario_anulacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ANULACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ANULACION_IDNull
		{
			get { return _usuario_anulacion_idNull; }
			set { _usuario_anulacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ANULACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ANULACION</c> column value.</value>
		public System.DateTime FECHA_ANULACION
		{
			get
			{
				if(IsFECHA_ANULACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_anulacion;
			}
			set
			{
				_fecha_anulacionNull = false;
				_fecha_anulacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ANULACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ANULACIONNull
		{
			get { return _fecha_anulacionNull; }
			set { _fecha_anulacionNull = value; }
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
			dynStr.Append("@CBA@CONTRATO_ID=");
			dynStr.Append(CONTRATO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@APROBADO=");
			dynStr.Append(APROBADO);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_ANULACION_ID=");
			dynStr.Append(IsUSUARIO_ANULACION_IDNull ? (object)"<NULL>" : USUARIO_ANULACION_ID);
			dynStr.Append("@CBA@FECHA_ANULACION=");
			dynStr.Append(IsFECHA_ANULACIONNull ? (object)"<NULL>" : FECHA_ANULACION);
			return dynStr.ToString();
		}
	} // End of ADENDASRow_Base class
} // End of namespace
