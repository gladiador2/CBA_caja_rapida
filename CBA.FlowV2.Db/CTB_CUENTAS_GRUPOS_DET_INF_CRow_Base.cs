// <fileinfo name="CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> that 
	/// represents a record in the <c>CTB_CUENTAS_GRUPOS_DET_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base
	{
		private decimal _id;
		private decimal _ctb_cuenta_id;
		private bool _ctb_cuenta_idNull = true;
		private string _cuenta_nombre;
		private decimal _ctb_cuentas_grupos_id;
		private string _cuenta_grupos_nombre;
		private string _cuenta_grupos_estado;
		private decimal _ctb_cuentas_grupos_hijo_id;
		private bool _ctb_cuentas_grupos_hijo_idNull = true;
		private string _cuenta_grupos_hijo_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base"/> class.
		/// </summary>
		public CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTB_CUENTA_IDNull != original.IsCTB_CUENTA_IDNull) return true;
			if (!this.IsCTB_CUENTA_IDNull && !original.IsCTB_CUENTA_IDNull)
				if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.CUENTA_NOMBRE != original.CUENTA_NOMBRE) return true;
			if (this.CTB_CUENTAS_GRUPOS_ID != original.CTB_CUENTAS_GRUPOS_ID) return true;
			if (this.CUENTA_GRUPOS_NOMBRE != original.CUENTA_GRUPOS_NOMBRE) return true;
			if (this.CUENTA_GRUPOS_ESTADO != original.CUENTA_GRUPOS_ESTADO) return true;
			if (this.IsCTB_CUENTAS_GRUPOS_HIJO_IDNull != original.IsCTB_CUENTAS_GRUPOS_HIJO_IDNull) return true;
			if (!this.IsCTB_CUENTAS_GRUPOS_HIJO_IDNull && !original.IsCTB_CUENTAS_GRUPOS_HIJO_IDNull)
				if (this.CTB_CUENTAS_GRUPOS_HIJO_ID != original.CTB_CUENTAS_GRUPOS_HIJO_ID) return true;
			if (this.CUENTA_GRUPOS_HIJO_NOMBRE != original.CUENTA_GRUPOS_HIJO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get
			{
				if(IsCTB_CUENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_id;
			}
			set
			{
				_ctb_cuenta_idNull = false;
				_ctb_cuenta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_IDNull
		{
			get { return _ctb_cuenta_idNull; }
			set { _ctb_cuenta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUENTA_NOMBRE</c> column value.</value>
		public string CUENTA_NOMBRE
		{
			get { return _cuenta_nombre; }
			set { _cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTAS_GRUPOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTAS_GRUPOS_ID</c> column value.</value>
		public decimal CTB_CUENTAS_GRUPOS_ID
		{
			get { return _ctb_cuentas_grupos_id; }
			set { _ctb_cuentas_grupos_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_GRUPOS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_GRUPOS_NOMBRE</c> column value.</value>
		public string CUENTA_GRUPOS_NOMBRE
		{
			get { return _cuenta_grupos_nombre; }
			set { _cuenta_grupos_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_GRUPOS_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_GRUPOS_ESTADO</c> column value.</value>
		public string CUENTA_GRUPOS_ESTADO
		{
			get { return _cuenta_grupos_estado; }
			set { _cuenta_grupos_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTAS_GRUPOS_HIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTAS_GRUPOS_HIJO_ID</c> column value.</value>
		public decimal CTB_CUENTAS_GRUPOS_HIJO_ID
		{
			get
			{
				if(IsCTB_CUENTAS_GRUPOS_HIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuentas_grupos_hijo_id;
			}
			set
			{
				_ctb_cuentas_grupos_hijo_idNull = false;
				_ctb_cuentas_grupos_hijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTAS_GRUPOS_HIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTAS_GRUPOS_HIJO_IDNull
		{
			get { return _ctb_cuentas_grupos_hijo_idNull; }
			set { _ctb_cuentas_grupos_hijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_GRUPOS_HIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUENTA_GRUPOS_HIJO_NOMBRE</c> column value.</value>
		public string CUENTA_GRUPOS_HIJO_NOMBRE
		{
			get { return _cuenta_grupos_hijo_nombre; }
			set { _cuenta_grupos_hijo_nombre = value; }
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
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(IsCTB_CUENTA_IDNull ? (object)"<NULL>" : CTB_CUENTA_ID);
			dynStr.Append("@CBA@CUENTA_NOMBRE=");
			dynStr.Append(CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTB_CUENTAS_GRUPOS_ID=");
			dynStr.Append(CTB_CUENTAS_GRUPOS_ID);
			dynStr.Append("@CBA@CUENTA_GRUPOS_NOMBRE=");
			dynStr.Append(CUENTA_GRUPOS_NOMBRE);
			dynStr.Append("@CBA@CUENTA_GRUPOS_ESTADO=");
			dynStr.Append(CUENTA_GRUPOS_ESTADO);
			dynStr.Append("@CBA@CTB_CUENTAS_GRUPOS_HIJO_ID=");
			dynStr.Append(IsCTB_CUENTAS_GRUPOS_HIJO_IDNull ? (object)"<NULL>" : CTB_CUENTAS_GRUPOS_HIJO_ID);
			dynStr.Append("@CBA@CUENTA_GRUPOS_HIJO_NOMBRE=");
			dynStr.Append(CUENTA_GRUPOS_HIJO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTB_CUENTAS_GRUPOS_DET_INF_CRow_Base class
} // End of namespace
