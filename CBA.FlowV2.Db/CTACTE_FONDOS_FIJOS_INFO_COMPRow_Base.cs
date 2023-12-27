// <fileinfo name="CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_FONDOS_FIJOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_FONDOS_FIJOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_FONDOS_FIJOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _nombre;
		private string _abreviatura;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _limite_superior;
		private bool _limite_superiorNull = true;
		private decimal _limite_inferior;
		private bool _limite_inferiorNull = true;
		private decimal _monto_sobregiro;
		private decimal _monto_actual;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsLIMITE_SUPERIORNull != original.IsLIMITE_SUPERIORNull) return true;
			if (!this.IsLIMITE_SUPERIORNull && !original.IsLIMITE_SUPERIORNull)
				if (this.LIMITE_SUPERIOR != original.LIMITE_SUPERIOR) return true;
			if (this.IsLIMITE_INFERIORNull != original.IsLIMITE_INFERIORNull) return true;
			if (!this.IsLIMITE_INFERIORNull && !original.IsLIMITE_INFERIORNull)
				if (this.LIMITE_INFERIOR != original.LIMITE_INFERIOR) return true;
			if (this.MONTO_SOBREGIRO != original.MONTO_SOBREGIRO) return true;
			if (this.MONTO_ACTUAL != original.MONTO_ACTUAL) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
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
		/// Gets or sets the <c>MONTO_SOBREGIRO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_SOBREGIRO</c> column value.</value>
		public decimal MONTO_SOBREGIRO
		{
			get { return _monto_sobregiro; }
			set { _monto_sobregiro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ACTUAL</c> column value.</value>
		public decimal MONTO_ACTUAL
		{
			get { return _monto_actual; }
			set { _monto_actual = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@LIMITE_SUPERIOR=");
			dynStr.Append(IsLIMITE_SUPERIORNull ? (object)"<NULL>" : LIMITE_SUPERIOR);
			dynStr.Append("@CBA@LIMITE_INFERIOR=");
			dynStr.Append(IsLIMITE_INFERIORNull ? (object)"<NULL>" : LIMITE_INFERIOR);
			dynStr.Append("@CBA@MONTO_SOBREGIRO=");
			dynStr.Append(MONTO_SOBREGIRO);
			dynStr.Append("@CBA@MONTO_ACTUAL=");
			dynStr.Append(MONTO_ACTUAL);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_FONDOS_FIJOS_INFO_COMPRow_Base class
} // End of namespace
