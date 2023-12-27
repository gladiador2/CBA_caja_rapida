// <fileinfo name="CTB_CUENTASRow_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTASRow"/> that 
	/// represents a record in the <c>CTB_CUENTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_CUENTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTASRow_Base
	{
		private decimal _id;
		private decimal _ctb_plan_cuenta_id;
		private decimal _ctb_cuenta_madre_id;
		private bool _ctb_cuenta_madre_idNull = true;
		private string _codigo;
		private decimal _nivel;
		private string _nombre;
		private string _asentable;
		private string _editable;
		private string _utilizar;
		private string _codigo_base;
		private string _desglosar;
		private decimal _ctb_clasificacion_cuentas_id;
		private bool _ctb_clasificacion_cuentas_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTASRow_Base"/> class.
		/// </summary>
		public CTB_CUENTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_CUENTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_PLAN_CUENTA_ID != original.CTB_PLAN_CUENTA_ID) return true;
			if (this.IsCTB_CUENTA_MADRE_IDNull != original.IsCTB_CUENTA_MADRE_IDNull) return true;
			if (!this.IsCTB_CUENTA_MADRE_IDNull && !original.IsCTB_CUENTA_MADRE_IDNull)
				if (this.CTB_CUENTA_MADRE_ID != original.CTB_CUENTA_MADRE_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NIVEL != original.NIVEL) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ASENTABLE != original.ASENTABLE) return true;
			if (this.EDITABLE != original.EDITABLE) return true;
			if (this.UTILIZAR != original.UTILIZAR) return true;
			if (this.CODIGO_BASE != original.CODIGO_BASE) return true;
			if (this.DESGLOSAR != original.DESGLOSAR) return true;
			if (this.IsCTB_CLASIFICACION_CUENTAS_IDNull != original.IsCTB_CLASIFICACION_CUENTAS_IDNull) return true;
			if (!this.IsCTB_CLASIFICACION_CUENTAS_IDNull && !original.IsCTB_CLASIFICACION_CUENTAS_IDNull)
				if (this.CTB_CLASIFICACION_CUENTAS_ID != original.CTB_CLASIFICACION_CUENTAS_ID) return true;
			
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
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ID</c> column value.</value>
		public decimal CTB_PLAN_CUENTA_ID
		{
			get { return _ctb_plan_cuenta_id; }
			set { _ctb_plan_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_MADRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_MADRE_ID</c> column value.</value>
		public decimal CTB_CUENTA_MADRE_ID
		{
			get
			{
				if(IsCTB_CUENTA_MADRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_madre_id;
			}
			set
			{
				_ctb_cuenta_madre_idNull = false;
				_ctb_cuenta_madre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_MADRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_MADRE_IDNull
		{
			get { return _ctb_cuenta_madre_idNull; }
			set { _ctb_cuenta_madre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NIVEL</c> column value.
		/// </summary>
		/// <value>The <c>NIVEL</c> column value.</value>
		public decimal NIVEL
		{
			get { return _nivel; }
			set { _nivel = value; }
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
		/// Gets or sets the <c>ASENTABLE</c> column value.
		/// </summary>
		/// <value>The <c>ASENTABLE</c> column value.</value>
		public string ASENTABLE
		{
			get { return _asentable; }
			set { _asentable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDITABLE</c> column value.
		/// </summary>
		/// <value>The <c>EDITABLE</c> column value.</value>
		public string EDITABLE
		{
			get { return _editable; }
			set { _editable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZAR</c> column value.
		/// </summary>
		/// <value>The <c>UTILIZAR</c> column value.</value>
		public string UTILIZAR
		{
			get { return _utilizar; }
			set { _utilizar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BASE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BASE</c> column value.</value>
		public string CODIGO_BASE
		{
			get { return _codigo_base; }
			set { _codigo_base = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESGLOSAR</c> column value.
		/// </summary>
		/// <value>The <c>DESGLOSAR</c> column value.</value>
		public string DESGLOSAR
		{
			get { return _desglosar; }
			set { _desglosar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</value>
		public decimal CTB_CLASIFICACION_CUENTAS_ID
		{
			get
			{
				if(IsCTB_CLASIFICACION_CUENTAS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_clasificacion_cuentas_id;
			}
			set
			{
				_ctb_clasificacion_cuentas_idNull = false;
				_ctb_clasificacion_cuentas_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CLASIFICACION_CUENTAS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CLASIFICACION_CUENTAS_IDNull
		{
			get { return _ctb_clasificacion_cuentas_idNull; }
			set { _ctb_clasificacion_cuentas_idNull = value; }
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
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ID=");
			dynStr.Append(CTB_PLAN_CUENTA_ID);
			dynStr.Append("@CBA@CTB_CUENTA_MADRE_ID=");
			dynStr.Append(IsCTB_CUENTA_MADRE_IDNull ? (object)"<NULL>" : CTB_CUENTA_MADRE_ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NIVEL=");
			dynStr.Append(NIVEL);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ASENTABLE=");
			dynStr.Append(ASENTABLE);
			dynStr.Append("@CBA@EDITABLE=");
			dynStr.Append(EDITABLE);
			dynStr.Append("@CBA@UTILIZAR=");
			dynStr.Append(UTILIZAR);
			dynStr.Append("@CBA@CODIGO_BASE=");
			dynStr.Append(CODIGO_BASE);
			dynStr.Append("@CBA@DESGLOSAR=");
			dynStr.Append(DESGLOSAR);
			dynStr.Append("@CBA@CTB_CLASIFICACION_CUENTAS_ID=");
			dynStr.Append(IsCTB_CLASIFICACION_CUENTAS_IDNull ? (object)"<NULL>" : CTB_CLASIFICACION_CUENTAS_ID);
			return dynStr.ToString();
		}
	} // End of CTB_CUENTASRow_Base class
} // End of namespace
