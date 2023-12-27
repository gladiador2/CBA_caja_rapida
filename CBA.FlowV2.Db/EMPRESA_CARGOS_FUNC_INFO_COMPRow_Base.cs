// <fileinfo name="EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> that 
	/// represents a record in the <c>EMPRESA_CARGOS_FUNC_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base
	{
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_nombre_completo;
		private string _funcionario_apellido;
		private decimal _marcaciones_id;
		private bool _marcaciones_idNull = true;
		private decimal _empresa_cargo_id;
		private decimal _porcentaje_cargo;
		private string _empresa_cargo_nombre;
		private decimal _empresa_seccion_id;
		private string _empresa_secciones_nombre;
		private string _empresa_departamento_id;
		private decimal _empresa_faja_id;
		private bool _empresa_faja_idNull = true;
		private string _empresa_fajas_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base"/> class.
		/// </summary>
		public EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base original)
		{
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.FUNCIONARIO_APELLIDO != original.FUNCIONARIO_APELLIDO) return true;
			if (this.IsMARCACIONES_IDNull != original.IsMARCACIONES_IDNull) return true;
			if (!this.IsMARCACIONES_IDNull && !original.IsMARCACIONES_IDNull)
				if (this.MARCACIONES_ID != original.MARCACIONES_ID) return true;
			if (this.EMPRESA_CARGO_ID != original.EMPRESA_CARGO_ID) return true;
			if (this.PORCENTAJE_CARGO != original.PORCENTAJE_CARGO) return true;
			if (this.EMPRESA_CARGO_NOMBRE != original.EMPRESA_CARGO_NOMBRE) return true;
			if (this.EMPRESA_SECCION_ID != original.EMPRESA_SECCION_ID) return true;
			if (this.EMPRESA_SECCIONES_NOMBRE != original.EMPRESA_SECCIONES_NOMBRE) return true;
			if (this.EMPRESA_DEPARTAMENTO_ID != original.EMPRESA_DEPARTAMENTO_ID) return true;
			if (this.IsEMPRESA_FAJA_IDNull != original.IsEMPRESA_FAJA_IDNull) return true;
			if (!this.IsEMPRESA_FAJA_IDNull && !original.IsEMPRESA_FAJA_IDNull)
				if (this.EMPRESA_FAJA_ID != original.EMPRESA_FAJA_ID) return true;
			if (this.EMPRESA_FAJAS_NOMBRE != original.EMPRESA_FAJAS_NOMBRE) return true;
			
			return false;
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
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.</value>
		public string FUNCIONARIO_NOMBRE_COMPLETO
		{
			get { return _funcionario_nombre_completo; }
			set { _funcionario_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_APELLIDO</c> column value.</value>
		public string FUNCIONARIO_APELLIDO
		{
			get { return _funcionario_apellido; }
			set { _funcionario_apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCACIONES_ID</c> column value.</value>
		public decimal MARCACIONES_ID
		{
			get
			{
				if(IsMARCACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _marcaciones_id;
			}
			set
			{
				_marcaciones_idNull = false;
				_marcaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MARCACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMARCACIONES_IDNull
		{
			get { return _marcaciones_idNull; }
			set { _marcaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_CARGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_CARGO_ID</c> column value.</value>
		public decimal EMPRESA_CARGO_ID
		{
			get { return _empresa_cargo_id; }
			set { _empresa_cargo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_CARGO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_CARGO</c> column value.</value>
		public decimal PORCENTAJE_CARGO
		{
			get { return _porcentaje_cargo; }
			set { _porcentaje_cargo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_CARGO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_CARGO_NOMBRE</c> column value.</value>
		public string EMPRESA_CARGO_NOMBRE
		{
			get { return _empresa_cargo_nombre; }
			set { _empresa_cargo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCION_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_ID</c> column value.</value>
		public decimal EMPRESA_SECCION_ID
		{
			get { return _empresa_seccion_id; }
			set { _empresa_seccion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCIONES_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCIONES_NOMBRE</c> column value.</value>
		public string EMPRESA_SECCIONES_NOMBRE
		{
			get { return _empresa_secciones_nombre; }
			set { _empresa_secciones_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_DEPARTAMENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</value>
		public string EMPRESA_DEPARTAMENTO_ID
		{
			get { return _empresa_departamento_id; }
			set { _empresa_departamento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_FAJA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_FAJA_ID</c> column value.</value>
		public decimal EMPRESA_FAJA_ID
		{
			get
			{
				if(IsEMPRESA_FAJA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _empresa_faja_id;
			}
			set
			{
				_empresa_faja_idNull = false;
				_empresa_faja_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EMPRESA_FAJA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEMPRESA_FAJA_IDNull
		{
			get { return _empresa_faja_idNull; }
			set { _empresa_faja_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_FAJAS_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_FAJAS_NOMBRE</c> column value.</value>
		public string EMPRESA_FAJAS_NOMBRE
		{
			get { return _empresa_fajas_nombre; }
			set { _empresa_fajas_nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FUNCIONARIO_APELLIDO=");
			dynStr.Append(FUNCIONARIO_APELLIDO);
			dynStr.Append("@CBA@MARCACIONES_ID=");
			dynStr.Append(IsMARCACIONES_IDNull ? (object)"<NULL>" : MARCACIONES_ID);
			dynStr.Append("@CBA@EMPRESA_CARGO_ID=");
			dynStr.Append(EMPRESA_CARGO_ID);
			dynStr.Append("@CBA@PORCENTAJE_CARGO=");
			dynStr.Append(PORCENTAJE_CARGO);
			dynStr.Append("@CBA@EMPRESA_CARGO_NOMBRE=");
			dynStr.Append(EMPRESA_CARGO_NOMBRE);
			dynStr.Append("@CBA@EMPRESA_SECCION_ID=");
			dynStr.Append(EMPRESA_SECCION_ID);
			dynStr.Append("@CBA@EMPRESA_SECCIONES_NOMBRE=");
			dynStr.Append(EMPRESA_SECCIONES_NOMBRE);
			dynStr.Append("@CBA@EMPRESA_DEPARTAMENTO_ID=");
			dynStr.Append(EMPRESA_DEPARTAMENTO_ID);
			dynStr.Append("@CBA@EMPRESA_FAJA_ID=");
			dynStr.Append(IsEMPRESA_FAJA_IDNull ? (object)"<NULL>" : EMPRESA_FAJA_ID);
			dynStr.Append("@CBA@EMPRESA_FAJAS_NOMBRE=");
			dynStr.Append(EMPRESA_FAJAS_NOMBRE);
			return dynStr.ToString();
		}
	} // End of EMPRESA_CARGOS_FUNC_INFO_COMPRow_Base class
} // End of namespace
