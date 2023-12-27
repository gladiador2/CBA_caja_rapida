// <fileinfo name="HORARIOS_FUNC_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="HORARIOS_FUNC_INFO_COMPLRow"/> that 
	/// represents a record in the <c>HORARIOS_FUNC_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HORARIOS_FUNC_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_FUNC_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _horario_id;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _empresa_seccion_id;
		private bool _empresa_seccion_idNull = true;
		private string _empresa_departamento_id;
		private string _funcionario_nombre;
		private string _depto_seccion_nombre;
		private string _depto_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_FUNC_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public HORARIOS_FUNC_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HORARIOS_FUNC_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.HORARIO_ID != original.HORARIO_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsEMPRESA_SECCION_IDNull != original.IsEMPRESA_SECCION_IDNull) return true;
			if (!this.IsEMPRESA_SECCION_IDNull && !original.IsEMPRESA_SECCION_IDNull)
				if (this.EMPRESA_SECCION_ID != original.EMPRESA_SECCION_ID) return true;
			if (this.EMPRESA_DEPARTAMENTO_ID != original.EMPRESA_DEPARTAMENTO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.DEPTO_SECCION_NOMBRE != original.DEPTO_SECCION_NOMBRE) return true;
			if (this.DEPTO_NOMBRE != original.DEPTO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>HORARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIO_ID</c> column value.</value>
		public decimal HORARIO_ID
		{
			get { return _horario_id; }
			set { _horario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_ID</c> column value.</value>
		public decimal EMPRESA_SECCION_ID
		{
			get
			{
				if(IsEMPRESA_SECCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _empresa_seccion_id;
			}
			set
			{
				_empresa_seccion_idNull = false;
				_empresa_seccion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EMPRESA_SECCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEMPRESA_SECCION_IDNull
		{
			get { return _empresa_seccion_idNull; }
			set { _empresa_seccion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_DEPARTAMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</value>
		public string EMPRESA_DEPARTAMENTO_ID
		{
			get { return _empresa_departamento_id; }
			set { _empresa_departamento_id = value; }
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
		/// Gets or sets the <c>DEPTO_SECCION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPTO_SECCION_NOMBRE</c> column value.</value>
		public string DEPTO_SECCION_NOMBRE
		{
			get { return _depto_seccion_nombre; }
			set { _depto_seccion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPTO_NOMBRE</c> column value.</value>
		public string DEPTO_NOMBRE
		{
			get { return _depto_nombre; }
			set { _depto_nombre = value; }
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
			dynStr.Append("@CBA@HORARIO_ID=");
			dynStr.Append(HORARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@EMPRESA_SECCION_ID=");
			dynStr.Append(IsEMPRESA_SECCION_IDNull ? (object)"<NULL>" : EMPRESA_SECCION_ID);
			dynStr.Append("@CBA@EMPRESA_DEPARTAMENTO_ID=");
			dynStr.Append(EMPRESA_DEPARTAMENTO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@DEPTO_SECCION_NOMBRE=");
			dynStr.Append(DEPTO_SECCION_NOMBRE);
			dynStr.Append("@CBA@DEPTO_NOMBRE=");
			dynStr.Append(DEPTO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of HORARIOS_FUNC_INFO_COMPLRow_Base class
} // End of namespace
