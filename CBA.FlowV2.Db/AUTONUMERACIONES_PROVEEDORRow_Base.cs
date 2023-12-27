// <fileinfo name="AUTONUMERACIONES_PROVEEDORRow_Base.cs">
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
	/// The base class for <see cref="AUTONUMERACIONES_PROVEEDORRow"/> that 
	/// represents a record in the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="AUTONUMERACIONES_PROVEEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AUTONUMERACIONES_PROVEEDORRow_Base
	{
		private decimal _id;
		private decimal _proveedores_id;
		private bool _proveedores_idNull = true;
		private string _numero_timbrado;
		private decimal _limite_inferior;
		private bool _limite_inferiorNull = true;
		private decimal _limite_superior;
		private bool _limite_superiorNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private string _prefijo;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private decimal _usuario_creacion_id;
		private bool _usuario_creacion_idNull = true;
		private string _estado;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="AUTONUMERACIONES_PROVEEDORRow_Base"/> class.
		/// </summary>
		public AUTONUMERACIONES_PROVEEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(AUTONUMERACIONES_PROVEEDORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsPROVEEDORES_IDNull != original.IsPROVEEDORES_IDNull) return true;
			if (!this.IsPROVEEDORES_IDNull && !original.IsPROVEEDORES_IDNull)
				if (this.PROVEEDORES_ID != original.PROVEEDORES_ID) return true;
			if (this.NUMERO_TIMBRADO != original.NUMERO_TIMBRADO) return true;
			if (this.IsLIMITE_INFERIORNull != original.IsLIMITE_INFERIORNull) return true;
			if (!this.IsLIMITE_INFERIORNull && !original.IsLIMITE_INFERIORNull)
				if (this.LIMITE_INFERIOR != original.LIMITE_INFERIOR) return true;
			if (this.IsLIMITE_SUPERIORNull != original.IsLIMITE_SUPERIORNull) return true;
			if (!this.IsLIMITE_SUPERIORNull && !original.IsLIMITE_SUPERIORNull)
				if (this.LIMITE_SUPERIOR != original.LIMITE_SUPERIOR) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.PREFIJO != original.PREFIJO) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_CREACION_IDNull != original.IsUSUARIO_CREACION_IDNull) return true;
			if (!this.IsUSUARIO_CREACION_IDNull && !original.IsUSUARIO_CREACION_IDNull)
				if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			
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
		/// Gets or sets the <c>PROVEEDORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDORES_ID</c> column value.</value>
		public decimal PROVEEDORES_ID
		{
			get
			{
				if(IsPROVEEDORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedores_id;
			}
			set
			{
				_proveedores_idNull = false;
				_proveedores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDORES_IDNull
		{
			get { return _proveedores_idNull; }
			set { _proveedores_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_TIMBRADO</c> column value.</value>
		public string NUMERO_TIMBRADO
		{
			get { return _numero_timbrado; }
			set { _numero_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_INFERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIMITE_INFERIOR</c> column value.</value>
		public decimal LIMITE_INFERIOR
		{
			get
			{
				if(IsLIMITE_INFERIORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _limite_inferior;
			}
			set
			{
				_limite_inferiorNull = false;
				_limite_inferior = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIMITE_INFERIOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIMITE_INFERIORNull
		{
			get { return _limite_inferiorNull; }
			set { _limite_inferiorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_SUPERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIMITE_SUPERIOR</c> column value.</value>
		public decimal LIMITE_SUPERIOR
		{
			get
			{
				if(IsLIMITE_SUPERIORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _limite_superior;
			}
			set
			{
				_limite_superiorNull = false;
				_limite_superior = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIMITE_SUPERIOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIMITE_SUPERIORNull
		{
			get { return _limite_superiorNull; }
			set { _limite_superiorNull = value; }
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
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREFIJO</c> column value.</value>
		public string PREFIJO
		{
			get { return _prefijo; }
			set { _prefijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get
			{
				if(IsUSUARIO_CREACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creacion_id;
			}
			set
			{
				_usuario_creacion_idNull = false;
				_usuario_creacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREACION_IDNull
		{
			get { return _usuario_creacion_idNull; }
			set { _usuario_creacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
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
			dynStr.Append("@CBA@PROVEEDORES_ID=");
			dynStr.Append(IsPROVEEDORES_IDNull ? (object)"<NULL>" : PROVEEDORES_ID);
			dynStr.Append("@CBA@NUMERO_TIMBRADO=");
			dynStr.Append(NUMERO_TIMBRADO);
			dynStr.Append("@CBA@LIMITE_INFERIOR=");
			dynStr.Append(IsLIMITE_INFERIORNull ? (object)"<NULL>" : LIMITE_INFERIOR);
			dynStr.Append("@CBA@LIMITE_SUPERIOR=");
			dynStr.Append(IsLIMITE_SUPERIORNull ? (object)"<NULL>" : LIMITE_SUPERIOR);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@PREFIJO=");
			dynStr.Append(PREFIJO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(IsUSUARIO_CREACION_IDNull ? (object)"<NULL>" : USUARIO_CREACION_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			return dynStr.ToString();
		}
	} // End of AUTONUMERACIONES_PROVEEDORRow_Base class
} // End of namespace
