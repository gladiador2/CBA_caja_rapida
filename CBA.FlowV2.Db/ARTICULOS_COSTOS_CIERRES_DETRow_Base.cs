// <fileinfo name="ARTICULOS_COSTOS_CIERRES_DETRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> that 
	/// represents a record in the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COSTOS_CIERRES_DETRow_Base
	{
		private decimal _id;
		private decimal _articulo_costo_cierre_id;
		private decimal _articulo_id;
		private decimal _cantidad_anterior;
		private decimal _cantidad_variacion_positiva;
		private decimal _costo_anterior;
		private decimal _costo_actual;
		private string _estado;
		private decimal _cantidad_variacion_negativa;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOS_CIERRES_DETRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COSTOS_CIERRES_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COSTOS_CIERRES_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_COSTO_CIERRE_ID != original.ARTICULO_COSTO_CIERRE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.CANTIDAD_ANTERIOR != original.CANTIDAD_ANTERIOR) return true;
			if (this.CANTIDAD_VARIACION_POSITIVA != original.CANTIDAD_VARIACION_POSITIVA) return true;
			if (this.COSTO_ANTERIOR != original.COSTO_ANTERIOR) return true;
			if (this.COSTO_ACTUAL != original.COSTO_ACTUAL) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CANTIDAD_VARIACION_NEGATIVA != original.CANTIDAD_VARIACION_NEGATIVA) return true;
			
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
		/// Gets or sets the <c>ARTICULO_COSTO_CIERRE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</value>
		public decimal ARTICULO_COSTO_CIERRE_ID
		{
			get { return _articulo_costo_cierre_id; }
			set { _articulo_costo_cierre_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_ANTERIOR</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_ANTERIOR</c> column value.</value>
		public decimal CANTIDAD_ANTERIOR
		{
			get { return _cantidad_anterior; }
			set { _cantidad_anterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_VARIACION_POSITIVA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_VARIACION_POSITIVA</c> column value.</value>
		public decimal CANTIDAD_VARIACION_POSITIVA
		{
			get { return _cantidad_variacion_positiva; }
			set { _cantidad_variacion_positiva = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ANTERIOR</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_ANTERIOR</c> column value.</value>
		public decimal COSTO_ANTERIOR
		{
			get { return _costo_anterior; }
			set { _costo_anterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_ACTUAL</c> column value.</value>
		public decimal COSTO_ACTUAL
		{
			get { return _costo_actual; }
			set { _costo_actual = value; }
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
		/// Gets or sets the <c>CANTIDAD_VARIACION_NEGATIVA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_VARIACION_NEGATIVA</c> column value.</value>
		public decimal CANTIDAD_VARIACION_NEGATIVA
		{
			get { return _cantidad_variacion_negativa; }
			set { _cantidad_variacion_negativa = value; }
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
			dynStr.Append("@CBA@ARTICULO_COSTO_CIERRE_ID=");
			dynStr.Append(ARTICULO_COSTO_CIERRE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD_ANTERIOR=");
			dynStr.Append(CANTIDAD_ANTERIOR);
			dynStr.Append("@CBA@CANTIDAD_VARIACION_POSITIVA=");
			dynStr.Append(CANTIDAD_VARIACION_POSITIVA);
			dynStr.Append("@CBA@COSTO_ANTERIOR=");
			dynStr.Append(COSTO_ANTERIOR);
			dynStr.Append("@CBA@COSTO_ACTUAL=");
			dynStr.Append(COSTO_ACTUAL);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CANTIDAD_VARIACION_NEGATIVA=");
			dynStr.Append(CANTIDAD_VARIACION_NEGATIVA);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COSTOS_CIERRES_DETRow_Base class
} // End of namespace
