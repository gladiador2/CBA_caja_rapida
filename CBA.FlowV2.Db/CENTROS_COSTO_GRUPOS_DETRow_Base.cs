// <fileinfo name="CENTROS_COSTO_GRUPOS_DETRow_Base.cs">
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
	/// The base class for <see cref="CENTROS_COSTO_GRUPOS_DETRow"/> that 
	/// represents a record in the <c>CENTROS_COSTO_GRUPOS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CENTROS_COSTO_GRUPOS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CENTROS_COSTO_GRUPOS_DETRow_Base
	{
		private decimal _id;
		private decimal _centro_costo_grupo_id;
		private decimal _porcentaje;
		private decimal _centro_costo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CENTROS_COSTO_GRUPOS_DETRow_Base"/> class.
		/// </summary>
		public CENTROS_COSTO_GRUPOS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CENTROS_COSTO_GRUPOS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CENTRO_COSTO_GRUPO_ID != original.CENTRO_COSTO_GRUPO_ID) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			
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
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
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
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(CENTRO_COSTO_ID);
			return dynStr.ToString();
		}
	} // End of CENTROS_COSTO_GRUPOS_DETRow_Base class
} // End of namespace
