// <fileinfo name="CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base.cs">
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
	/// The base class for <see cref="CENTROS_COSTO_GRUPOS_DET_INF_CRow"/> that 
	/// represents a record in the <c>CENTROS_COSTO_GRUPOS_DET_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CENTROS_COSTO_GRUPOS_DET_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base
	{
		private decimal _id;
		private decimal _centro_costo_grupo_id;
		private string _centro_costo_grupo_nombre;
		private decimal _centro_costo_id;
		private string _centro_costo_nombre;
		private string _centro_costo_abreviatura;
		private decimal _porcentaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base"/> class.
		/// </summary>
		public CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CENTRO_COSTO_GRUPO_ID != original.CENTRO_COSTO_GRUPO_ID) return true;
			if (this.CENTRO_COSTO_GRUPO_NOMBRE != original.CENTRO_COSTO_GRUPO_NOMBRE) return true;
			if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.CENTRO_COSTO_NOMBRE != original.CENTRO_COSTO_NOMBRE) return true;
			if (this.CENTRO_COSTO_ABREVIATURA != original.CENTRO_COSTO_ABREVIATURA) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			
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
		/// Gets or sets the <c>CENTRO_COSTO_GRUPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_GRUPO_ID
		{
			get { return _centro_costo_grupo_id; }
			set { _centro_costo_grupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_GRUPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_GRUPO_NOMBRE</c> column value.</value>
		public string CENTRO_COSTO_GRUPO_NOMBRE
		{
			get { return _centro_costo_grupo_nombre; }
			set { _centro_costo_grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get { return _centro_costo_id; }
			set { _centro_costo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_NOMBRE</c> column value.</value>
		public string CENTRO_COSTO_NOMBRE
		{
			get { return _centro_costo_nombre; }
			set { _centro_costo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ABREVIATURA</c> column value.</value>
		public string CENTRO_COSTO_ABREVIATURA
		{
			get { return _centro_costo_abreviatura; }
			set { _centro_costo_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
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
			dynStr.Append("@CBA@CENTRO_COSTO_GRUPO_ID=");
			dynStr.Append(CENTRO_COSTO_GRUPO_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_GRUPO_NOMBRE=");
			dynStr.Append(CENTRO_COSTO_GRUPO_NOMBRE);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(CENTRO_COSTO_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_NOMBRE=");
			dynStr.Append(CENTRO_COSTO_NOMBRE);
			dynStr.Append("@CBA@CENTRO_COSTO_ABREVIATURA=");
			dynStr.Append(CENTRO_COSTO_ABREVIATURA);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of CENTROS_COSTO_GRUPOS_DET_INF_CRow_Base class
} // End of namespace
