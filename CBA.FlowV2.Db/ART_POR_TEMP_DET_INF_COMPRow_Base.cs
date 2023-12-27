// <fileinfo name="ART_POR_TEMP_DET_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="ART_POR_TEMP_DET_INF_COMPRow"/> that 
	/// represents a record in the <c>ART_POR_TEMP_DET_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ART_POR_TEMP_DET_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_POR_TEMP_DET_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _articulos_por_temporada_id;
		private string _nombre_lista;
		private decimal _articulo_id;
		private string _articulo;
		private decimal _cantidad_objetivo;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_POR_TEMP_DET_INF_COMPRow_Base"/> class.
		/// </summary>
		public ART_POR_TEMP_DET_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ART_POR_TEMP_DET_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULOS_POR_TEMPORADA_ID != original.ARTICULOS_POR_TEMPORADA_ID) return true;
			if (this.NOMBRE_LISTA != original.NOMBRE_LISTA) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO != original.ARTICULO) return true;
			if (this.CANTIDAD_OBJETIVO != original.CANTIDAD_OBJETIVO) return true;
			
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
		/// Gets or sets the <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</value>
		public decimal ARTICULOS_POR_TEMPORADA_ID
		{
			get { return _articulos_por_temporada_id; }
			set { _articulos_por_temporada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_LISTA</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_LISTA</c> column value.</value>
		public string NOMBRE_LISTA
		{
			get { return _nombre_lista; }
			set { _nombre_lista = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO</c> column value.</value>
		public string ARTICULO
		{
			get { return _articulo; }
			set { _articulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_OBJETIVO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_OBJETIVO</c> column value.</value>
		public decimal CANTIDAD_OBJETIVO
		{
			get { return _cantidad_objetivo; }
			set { _cantidad_objetivo = value; }
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
			dynStr.Append("@CBA@ARTICULOS_POR_TEMPORADA_ID=");
			dynStr.Append(ARTICULOS_POR_TEMPORADA_ID);
			dynStr.Append("@CBA@NOMBRE_LISTA=");
			dynStr.Append(NOMBRE_LISTA);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO=");
			dynStr.Append(ARTICULO);
			dynStr.Append("@CBA@CANTIDAD_OBJETIVO=");
			dynStr.Append(CANTIDAD_OBJETIVO);
			return dynStr.ToString();
		}
	} // End of ART_POR_TEMP_DET_INF_COMPRow_Base class
} // End of namespace
