// <fileinfo name="CTB_INDICADORES_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTB_INDICADORES_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTB_INDICADORES_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_INDICADORES_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_INDICADORES_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctb_indicador_id;
		private string _ctb_indicador_nombre;
		private decimal _ctb_indicadores_detalle_1;
		private bool _ctb_indicadores_detalle_1Null = true;
		private decimal _ctb_indicadores_detalle_2;
		private bool _ctb_indicadores_detalle_2Null = true;
		private decimal _operacion;
		private bool _operacionNull = true;
		private string _operacion_nombre;
		private string _operacion_simbolo;
		private decimal _ctb_indicadores_detalle_padre;
		private bool _ctb_indicadores_detalle_padreNull = true;
		private decimal _ctb_cuenta;
		private bool _ctb_cuentaNull = true;
		private string _ctb_cuenta_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORES_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTB_INDICADORES_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_INDICADORES_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_INDICADOR_ID != original.CTB_INDICADOR_ID) return true;
			if (this.CTB_INDICADOR_NOMBRE != original.CTB_INDICADOR_NOMBRE) return true;
			if (this.IsCTB_INDICADORES_DETALLE_1Null != original.IsCTB_INDICADORES_DETALLE_1Null) return true;
			if (!this.IsCTB_INDICADORES_DETALLE_1Null && !original.IsCTB_INDICADORES_DETALLE_1Null)
				if (this.CTB_INDICADORES_DETALLE_1 != original.CTB_INDICADORES_DETALLE_1) return true;
			if (this.IsCTB_INDICADORES_DETALLE_2Null != original.IsCTB_INDICADORES_DETALLE_2Null) return true;
			if (!this.IsCTB_INDICADORES_DETALLE_2Null && !original.IsCTB_INDICADORES_DETALLE_2Null)
				if (this.CTB_INDICADORES_DETALLE_2 != original.CTB_INDICADORES_DETALLE_2) return true;
			if (this.IsOPERACIONNull != original.IsOPERACIONNull) return true;
			if (!this.IsOPERACIONNull && !original.IsOPERACIONNull)
				if (this.OPERACION != original.OPERACION) return true;
			if (this.OPERACION_NOMBRE != original.OPERACION_NOMBRE) return true;
			if (this.OPERACION_SIMBOLO != original.OPERACION_SIMBOLO) return true;
			if (this.IsCTB_INDICADORES_DETALLE_PADRENull != original.IsCTB_INDICADORES_DETALLE_PADRENull) return true;
			if (!this.IsCTB_INDICADORES_DETALLE_PADRENull && !original.IsCTB_INDICADORES_DETALLE_PADRENull)
				if (this.CTB_INDICADORES_DETALLE_PADRE != original.CTB_INDICADORES_DETALLE_PADRE) return true;
			if (this.IsCTB_CUENTANull != original.IsCTB_CUENTANull) return true;
			if (!this.IsCTB_CUENTANull && !original.IsCTB_CUENTANull)
				if (this.CTB_CUENTA != original.CTB_CUENTA) return true;
			if (this.CTB_CUENTA_NOMBRE != original.CTB_CUENTA_NOMBRE) return true;
			
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
		/// Gets or sets the <c>CTB_INDICADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_INDICADOR_ID</c> column value.</value>
		public decimal CTB_INDICADOR_ID
		{
			get { return _ctb_indicador_id; }
			set { _ctb_indicador_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_INDICADOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_INDICADOR_NOMBRE</c> column value.</value>
		public string CTB_INDICADOR_NOMBRE
		{
			get { return _ctb_indicador_nombre; }
			set { _ctb_indicador_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_INDICADORES_DETALLE_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_INDICADORES_DETALLE_1</c> column value.</value>
		public decimal CTB_INDICADORES_DETALLE_1
		{
			get
			{
				if(IsCTB_INDICADORES_DETALLE_1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_indicadores_detalle_1;
			}
			set
			{
				_ctb_indicadores_detalle_1Null = false;
				_ctb_indicadores_detalle_1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_INDICADORES_DETALLE_1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_INDICADORES_DETALLE_1Null
		{
			get { return _ctb_indicadores_detalle_1Null; }
			set { _ctb_indicadores_detalle_1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_INDICADORES_DETALLE_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_INDICADORES_DETALLE_2</c> column value.</value>
		public decimal CTB_INDICADORES_DETALLE_2
		{
			get
			{
				if(IsCTB_INDICADORES_DETALLE_2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_indicadores_detalle_2;
			}
			set
			{
				_ctb_indicadores_detalle_2Null = false;
				_ctb_indicadores_detalle_2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_INDICADORES_DETALLE_2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_INDICADORES_DETALLE_2Null
		{
			get { return _ctb_indicadores_detalle_2Null; }
			set { _ctb_indicadores_detalle_2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OPERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION</c> column value.</value>
		public decimal OPERACION
		{
			get
			{
				if(IsOPERACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _operacion;
			}
			set
			{
				_operacionNull = false;
				_operacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="OPERACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsOPERACIONNull
		{
			get { return _operacionNull; }
			set { _operacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OPERACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION_NOMBRE</c> column value.</value>
		public string OPERACION_NOMBRE
		{
			get { return _operacion_nombre; }
			set { _operacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OPERACION_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION_SIMBOLO</c> column value.</value>
		public string OPERACION_SIMBOLO
		{
			get { return _operacion_simbolo; }
			set { _operacion_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</value>
		public decimal CTB_INDICADORES_DETALLE_PADRE
		{
			get
			{
				if(IsCTB_INDICADORES_DETALLE_PADRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_indicadores_detalle_padre;
			}
			set
			{
				_ctb_indicadores_detalle_padreNull = false;
				_ctb_indicadores_detalle_padre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_INDICADORES_DETALLE_PADRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_INDICADORES_DETALLE_PADRENull
		{
			get { return _ctb_indicadores_detalle_padreNull; }
			set { _ctb_indicadores_detalle_padreNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA</c> column value.</value>
		public decimal CTB_CUENTA
		{
			get
			{
				if(IsCTB_CUENTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta;
			}
			set
			{
				_ctb_cuentaNull = false;
				_ctb_cuenta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTANull
		{
			get { return _ctb_cuentaNull; }
			set { _ctb_cuentaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_CUENTA_NOMBRE
		{
			get { return _ctb_cuenta_nombre; }
			set { _ctb_cuenta_nombre = value; }
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
			dynStr.Append("@CBA@CTB_INDICADOR_ID=");
			dynStr.Append(CTB_INDICADOR_ID);
			dynStr.Append("@CBA@CTB_INDICADOR_NOMBRE=");
			dynStr.Append(CTB_INDICADOR_NOMBRE);
			dynStr.Append("@CBA@CTB_INDICADORES_DETALLE_1=");
			dynStr.Append(IsCTB_INDICADORES_DETALLE_1Null ? (object)"<NULL>" : CTB_INDICADORES_DETALLE_1);
			dynStr.Append("@CBA@CTB_INDICADORES_DETALLE_2=");
			dynStr.Append(IsCTB_INDICADORES_DETALLE_2Null ? (object)"<NULL>" : CTB_INDICADORES_DETALLE_2);
			dynStr.Append("@CBA@OPERACION=");
			dynStr.Append(IsOPERACIONNull ? (object)"<NULL>" : OPERACION);
			dynStr.Append("@CBA@OPERACION_NOMBRE=");
			dynStr.Append(OPERACION_NOMBRE);
			dynStr.Append("@CBA@OPERACION_SIMBOLO=");
			dynStr.Append(OPERACION_SIMBOLO);
			dynStr.Append("@CBA@CTB_INDICADORES_DETALLE_PADRE=");
			dynStr.Append(IsCTB_INDICADORES_DETALLE_PADRENull ? (object)"<NULL>" : CTB_INDICADORES_DETALLE_PADRE);
			dynStr.Append("@CBA@CTB_CUENTA=");
			dynStr.Append(IsCTB_CUENTANull ? (object)"<NULL>" : CTB_CUENTA);
			dynStr.Append("@CBA@CTB_CUENTA_NOMBRE=");
			dynStr.Append(CTB_CUENTA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTB_INDICADORES_DET_INFO_COMPLRow_Base class
} // End of namespace
