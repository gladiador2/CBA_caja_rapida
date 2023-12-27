// <fileinfo name="IMPORTACIONES_PROVE_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_PROVE_INFO_COMPRow"/> that 
	/// represents a record in the <c>IMPORTACIONES_PROVE_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACIONES_PROVE_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_PROVE_INFO_COMPRow_Base
	{
		private decimal _importacion_id;
		private decimal _proveedor_id;
		private string _proveedor;
		private string _se_puede_modificar;
		private string _finalizado;
		private string _importacion_descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_PROVE_INFO_COMPRow_Base"/> class.
		/// </summary>
		public IMPORTACIONES_PROVE_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACIONES_PROVE_INFO_COMPRow_Base original)
		{
			if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR != original.PROVEEDOR) return true;
			if (this.SE_PUEDE_MODIFICAR != original.SE_PUEDE_MODIFICAR) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			if (this.IMPORTACION_DESCRIPCION != original.IMPORTACION_DESCRIPCION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get { return _importacion_id; }
			set { _importacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR</c> column value.</value>
		public string PROVEEDOR
		{
			get { return _proveedor; }
			set { _proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SE_PUEDE_MODIFICAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SE_PUEDE_MODIFICAR</c> column value.</value>
		public string SE_PUEDE_MODIFICAR
		{
			get { return _se_puede_modificar; }
			set { _se_puede_modificar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FINALIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FINALIZADO</c> column value.</value>
		public string FINALIZADO
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_DESCRIPCION</c> column value.</value>
		public string IMPORTACION_DESCRIPCION
		{
			get { return _importacion_descripcion; }
			set { _importacion_descripcion = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IMPORTACION_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR=");
			dynStr.Append(PROVEEDOR);
			dynStr.Append("@CBA@SE_PUEDE_MODIFICAR=");
			dynStr.Append(SE_PUEDE_MODIFICAR);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			dynStr.Append("@CBA@IMPORTACION_DESCRIPCION=");
			dynStr.Append(IMPORTACION_DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of IMPORTACIONES_PROVE_INFO_COMPRow_Base class
} // End of namespace
