// <fileinfo name="FUNC_HIJOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="FUNC_HIJOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>FUNC_HIJOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNC_HIJOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNC_HIJOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private string _nombre;
		private System.DateTime _fecha_nacimiento;
		private decimal _edad;
		private bool _edadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNC_HIJOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public FUNC_HIJOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNC_HIJOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.FECHA_NACIMIENTO != original.FECHA_NACIMIENTO) return true;
			if (this.IsEDADNull != original.IsEDADNull) return true;
			if (!this.IsEDADNull && !original.IsEDADNull)
				if (this.EDAD != original.EDAD) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
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
		/// Gets or sets the <c>FECHA_NACIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_NACIMIENTO</c> column value.</value>
		public System.DateTime FECHA_NACIMIENTO
		{
			get { return _fecha_nacimiento; }
			set { _fecha_nacimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDAD</c> column value.</value>
		public decimal EDAD
		{
			get
			{
				if(IsEDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _edad;
			}
			set
			{
				_edadNull = false;
				_edad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEDADNull
		{
			get { return _edadNull; }
			set { _edadNull = value; }
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
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@FECHA_NACIMIENTO=");
			dynStr.Append(FECHA_NACIMIENTO);
			dynStr.Append("@CBA@EDAD=");
			dynStr.Append(IsEDADNull ? (object)"<NULL>" : EDAD);
			return dynStr.ToString();
		}
	} // End of FUNC_HIJOS_INFO_COMPLRow_Base class
} // End of namespace
