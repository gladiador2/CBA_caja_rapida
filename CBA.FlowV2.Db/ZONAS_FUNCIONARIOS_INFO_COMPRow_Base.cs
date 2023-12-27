// <fileinfo name="ZONAS_FUNCIONARIOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="ZONAS_FUNCIONARIOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>ZONAS_FUNCIONARIOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ZONAS_FUNCIONARIOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ZONAS_FUNCIONARIOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _zonas_id;
		private string _zona_nombre;
		private string _zona_abreviatura;
		private decimal _funcionario_id;
		private string _funcionario_nombre_completo;
		private string _funcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZONAS_FUNCIONARIOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public ZONAS_FUNCIONARIOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ZONAS_FUNCIONARIOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ZONAS_ID != original.ZONAS_ID) return true;
			if (this.ZONA_NOMBRE != original.ZONA_NOMBRE) return true;
			if (this.ZONA_ABREVIATURA != original.ZONA_ABREVIATURA) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.FUNCION != original.FUNCION) return true;
			
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
		/// Gets or sets the <c>ZONAS_ID</c> column value.
		/// </summary>
		/// <value>The <c>ZONAS_ID</c> column value.</value>
		public decimal ZONAS_ID
		{
			get { return _zonas_id; }
			set { _zonas_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ZONA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ZONA_NOMBRE</c> column value.</value>
		public string ZONA_NOMBRE
		{
			get { return _zona_nombre; }
			set { _zona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ZONA_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ZONA_ABREVIATURA</c> column value.</value>
		public string ZONA_ABREVIATURA
		{
			get { return _zona_abreviatura; }
			set { _zona_abreviatura = value; }
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
		/// Gets or sets the <c>FUNCION</c> column value.
		/// </summary>
		/// <value>The <c>FUNCION</c> column value.</value>
		public string FUNCION
		{
			get { return _funcion; }
			set { _funcion = value; }
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
			dynStr.Append("@CBA@ZONAS_ID=");
			dynStr.Append(ZONAS_ID);
			dynStr.Append("@CBA@ZONA_NOMBRE=");
			dynStr.Append(ZONA_NOMBRE);
			dynStr.Append("@CBA@ZONA_ABREVIATURA=");
			dynStr.Append(ZONA_ABREVIATURA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FUNCION=");
			dynStr.Append(FUNCION);
			return dynStr.ToString();
		}
	} // End of ZONAS_FUNCIONARIOS_INFO_COMPRow_Base class
} // End of namespace
