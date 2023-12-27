// <fileinfo name="EMPRESA_CARGOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="EMPRESA_CARGOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>EMPRESA_CARGOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EMPRESA_CARGOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EMPRESA_CARGOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private string _estado;
		private decimal _empresa_seccion_id;
		private decimal _empresa_faja_id;
		private bool _empresa_faja_idNull = true;
		private string _empresa_secciones_nombre;
		private string _empresa_departamento_id;
		private string _empresa_faja_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_CARGOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public EMPRESA_CARGOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EMPRESA_CARGOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.EMPRESA_SECCION_ID != original.EMPRESA_SECCION_ID) return true;
			if (this.IsEMPRESA_FAJA_IDNull != original.IsEMPRESA_FAJA_IDNull) return true;
			if (!this.IsEMPRESA_FAJA_IDNull && !original.IsEMPRESA_FAJA_IDNull)
				if (this.EMPRESA_FAJA_ID != original.EMPRESA_FAJA_ID) return true;
			if (this.EMPRESA_SECCIONES_NOMBRE != original.EMPRESA_SECCIONES_NOMBRE) return true;
			if (this.EMPRESA_DEPARTAMENTO_ID != original.EMPRESA_DEPARTAMENTO_ID) return true;
			if (this.EMPRESA_FAJA_NOMBRE != original.EMPRESA_FAJA_NOMBRE) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
		/// Gets or sets the <c>EMPRESA_SECCION_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_ID</c> column value.</value>
		public decimal EMPRESA_SECCION_ID
		{
			get { return _empresa_seccion_id; }
			set { _empresa_seccion_id = value; }
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
		/// Gets or sets the <c>EMPRESA_FAJA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_FAJA_NOMBRE</c> column value.</value>
		public string EMPRESA_FAJA_NOMBRE
		{
			get { return _empresa_faja_nombre; }
			set { _empresa_faja_nombre = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@EMPRESA_SECCION_ID=");
			dynStr.Append(EMPRESA_SECCION_ID);
			dynStr.Append("@CBA@EMPRESA_FAJA_ID=");
			dynStr.Append(IsEMPRESA_FAJA_IDNull ? (object)"<NULL>" : EMPRESA_FAJA_ID);
			dynStr.Append("@CBA@EMPRESA_SECCIONES_NOMBRE=");
			dynStr.Append(EMPRESA_SECCIONES_NOMBRE);
			dynStr.Append("@CBA@EMPRESA_DEPARTAMENTO_ID=");
			dynStr.Append(EMPRESA_DEPARTAMENTO_ID);
			dynStr.Append("@CBA@EMPRESA_FAJA_NOMBRE=");
			dynStr.Append(EMPRESA_FAJA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of EMPRESA_CARGOS_INFO_COMPRow_Base class
} // End of namespace
