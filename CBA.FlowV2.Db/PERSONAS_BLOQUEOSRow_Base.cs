// <fileinfo name="PERSONAS_BLOQUEOSRow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_BLOQUEOSRow"/> that 
	/// represents a record in the <c>PERSONAS_BLOQUEOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_BLOQUEOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_BLOQUEOSRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _usuario_bloqueo_id;
		private System.DateTime _fecha_bloqueo;
		private decimal _texto_motivo_id;
		private decimal _usuario_desbloqueo1_id;
		private bool _usuario_desbloqueo1_idNull = true;
		private decimal _usuario_desbloqueo2_id;
		private bool _usuario_desbloqueo2_idNull = true;
		private decimal _usuario_desbloqueo3_id;
		private bool _usuario_desbloqueo3_idNull = true;
		private System.DateTime _fecha_desbloqueo1;
		private bool _fecha_desbloqueo1Null = true;
		private System.DateTime _fecha_desbloqueo2;
		private bool _fecha_desbloqueo2Null = true;
		private System.DateTime _fecha_desbloqueo3;
		private bool _fecha_desbloqueo3Null = true;
		private string _desbloqueado;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_BLOQUEOSRow_Base"/> class.
		/// </summary>
		public PERSONAS_BLOQUEOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_BLOQUEOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.USUARIO_BLOQUEO_ID != original.USUARIO_BLOQUEO_ID) return true;
			if (this.FECHA_BLOQUEO != original.FECHA_BLOQUEO) return true;
			if (this.TEXTO_MOTIVO_ID != original.TEXTO_MOTIVO_ID) return true;
			if (this.IsUSUARIO_DESBLOQUEO1_IDNull != original.IsUSUARIO_DESBLOQUEO1_IDNull) return true;
			if (!this.IsUSUARIO_DESBLOQUEO1_IDNull && !original.IsUSUARIO_DESBLOQUEO1_IDNull)
				if (this.USUARIO_DESBLOQUEO1_ID != original.USUARIO_DESBLOQUEO1_ID) return true;
			if (this.IsUSUARIO_DESBLOQUEO2_IDNull != original.IsUSUARIO_DESBLOQUEO2_IDNull) return true;
			if (!this.IsUSUARIO_DESBLOQUEO2_IDNull && !original.IsUSUARIO_DESBLOQUEO2_IDNull)
				if (this.USUARIO_DESBLOQUEO2_ID != original.USUARIO_DESBLOQUEO2_ID) return true;
			if (this.IsUSUARIO_DESBLOQUEO3_IDNull != original.IsUSUARIO_DESBLOQUEO3_IDNull) return true;
			if (!this.IsUSUARIO_DESBLOQUEO3_IDNull && !original.IsUSUARIO_DESBLOQUEO3_IDNull)
				if (this.USUARIO_DESBLOQUEO3_ID != original.USUARIO_DESBLOQUEO3_ID) return true;
			if (this.IsFECHA_DESBLOQUEO1Null != original.IsFECHA_DESBLOQUEO1Null) return true;
			if (!this.IsFECHA_DESBLOQUEO1Null && !original.IsFECHA_DESBLOQUEO1Null)
				if (this.FECHA_DESBLOQUEO1 != original.FECHA_DESBLOQUEO1) return true;
			if (this.IsFECHA_DESBLOQUEO2Null != original.IsFECHA_DESBLOQUEO2Null) return true;
			if (!this.IsFECHA_DESBLOQUEO2Null && !original.IsFECHA_DESBLOQUEO2Null)
				if (this.FECHA_DESBLOQUEO2 != original.FECHA_DESBLOQUEO2) return true;
			if (this.IsFECHA_DESBLOQUEO3Null != original.IsFECHA_DESBLOQUEO3Null) return true;
			if (!this.IsFECHA_DESBLOQUEO3Null && !original.IsFECHA_DESBLOQUEO3Null)
				if (this.FECHA_DESBLOQUEO3 != original.FECHA_DESBLOQUEO3) return true;
			if (this.DESBLOQUEADO != original.DESBLOQUEADO) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_BLOQUEO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_BLOQUEO_ID</c> column value.</value>
		public decimal USUARIO_BLOQUEO_ID
		{
			get { return _usuario_bloqueo_id; }
			set { _usuario_bloqueo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_BLOQUEO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_BLOQUEO</c> column value.</value>
		public System.DateTime FECHA_BLOQUEO
		{
			get { return _fecha_bloqueo; }
			set { _fecha_bloqueo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_MOTIVO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_MOTIVO_ID</c> column value.</value>
		public decimal TEXTO_MOTIVO_ID
		{
			get { return _texto_motivo_id; }
			set { _texto_motivo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESBLOQUEO1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</value>
		public decimal USUARIO_DESBLOQUEO1_ID
		{
			get
			{
				if(IsUSUARIO_DESBLOQUEO1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desbloqueo1_id;
			}
			set
			{
				_usuario_desbloqueo1_idNull = false;
				_usuario_desbloqueo1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESBLOQUEO1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESBLOQUEO1_IDNull
		{
			get { return _usuario_desbloqueo1_idNull; }
			set { _usuario_desbloqueo1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESBLOQUEO2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</value>
		public decimal USUARIO_DESBLOQUEO2_ID
		{
			get
			{
				if(IsUSUARIO_DESBLOQUEO2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desbloqueo2_id;
			}
			set
			{
				_usuario_desbloqueo2_idNull = false;
				_usuario_desbloqueo2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESBLOQUEO2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESBLOQUEO2_IDNull
		{
			get { return _usuario_desbloqueo2_idNull; }
			set { _usuario_desbloqueo2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESBLOQUEO3_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</value>
		public decimal USUARIO_DESBLOQUEO3_ID
		{
			get
			{
				if(IsUSUARIO_DESBLOQUEO3_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desbloqueo3_id;
			}
			set
			{
				_usuario_desbloqueo3_idNull = false;
				_usuario_desbloqueo3_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESBLOQUEO3_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESBLOQUEO3_IDNull
		{
			get { return _usuario_desbloqueo3_idNull; }
			set { _usuario_desbloqueo3_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESBLOQUEO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESBLOQUEO1</c> column value.</value>
		public System.DateTime FECHA_DESBLOQUEO1
		{
			get
			{
				if(IsFECHA_DESBLOQUEO1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desbloqueo1;
			}
			set
			{
				_fecha_desbloqueo1Null = false;
				_fecha_desbloqueo1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESBLOQUEO1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESBLOQUEO1Null
		{
			get { return _fecha_desbloqueo1Null; }
			set { _fecha_desbloqueo1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESBLOQUEO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESBLOQUEO2</c> column value.</value>
		public System.DateTime FECHA_DESBLOQUEO2
		{
			get
			{
				if(IsFECHA_DESBLOQUEO2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desbloqueo2;
			}
			set
			{
				_fecha_desbloqueo2Null = false;
				_fecha_desbloqueo2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESBLOQUEO2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESBLOQUEO2Null
		{
			get { return _fecha_desbloqueo2Null; }
			set { _fecha_desbloqueo2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESBLOQUEO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESBLOQUEO3</c> column value.</value>
		public System.DateTime FECHA_DESBLOQUEO3
		{
			get
			{
				if(IsFECHA_DESBLOQUEO3Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desbloqueo3;
			}
			set
			{
				_fecha_desbloqueo3Null = false;
				_fecha_desbloqueo3 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESBLOQUEO3"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESBLOQUEO3Null
		{
			get { return _fecha_desbloqueo3Null; }
			set { _fecha_desbloqueo3Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESBLOQUEADO</c> column value.
		/// </summary>
		/// <value>The <c>DESBLOQUEADO</c> column value.</value>
		public string DESBLOQUEADO
		{
			get { return _desbloqueado; }
			set { _desbloqueado = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@USUARIO_BLOQUEO_ID=");
			dynStr.Append(USUARIO_BLOQUEO_ID);
			dynStr.Append("@CBA@FECHA_BLOQUEO=");
			dynStr.Append(FECHA_BLOQUEO);
			dynStr.Append("@CBA@TEXTO_MOTIVO_ID=");
			dynStr.Append(TEXTO_MOTIVO_ID);
			dynStr.Append("@CBA@USUARIO_DESBLOQUEO1_ID=");
			dynStr.Append(IsUSUARIO_DESBLOQUEO1_IDNull ? (object)"<NULL>" : USUARIO_DESBLOQUEO1_ID);
			dynStr.Append("@CBA@USUARIO_DESBLOQUEO2_ID=");
			dynStr.Append(IsUSUARIO_DESBLOQUEO2_IDNull ? (object)"<NULL>" : USUARIO_DESBLOQUEO2_ID);
			dynStr.Append("@CBA@USUARIO_DESBLOQUEO3_ID=");
			dynStr.Append(IsUSUARIO_DESBLOQUEO3_IDNull ? (object)"<NULL>" : USUARIO_DESBLOQUEO3_ID);
			dynStr.Append("@CBA@FECHA_DESBLOQUEO1=");
			dynStr.Append(IsFECHA_DESBLOQUEO1Null ? (object)"<NULL>" : FECHA_DESBLOQUEO1);
			dynStr.Append("@CBA@FECHA_DESBLOQUEO2=");
			dynStr.Append(IsFECHA_DESBLOQUEO2Null ? (object)"<NULL>" : FECHA_DESBLOQUEO2);
			dynStr.Append("@CBA@FECHA_DESBLOQUEO3=");
			dynStr.Append(IsFECHA_DESBLOQUEO3Null ? (object)"<NULL>" : FECHA_DESBLOQUEO3);
			dynStr.Append("@CBA@DESBLOQUEADO=");
			dynStr.Append(DESBLOQUEADO);
			return dynStr.ToString();
		}
	} // End of PERSONAS_BLOQUEOSRow_Base class
} // End of namespace
