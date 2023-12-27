// <fileinfo name="CENTROS_COSTORow_Base.cs">
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
	/// The base class for <see cref="CENTROS_COSTORow"/> that 
	/// represents a record in the <c>CENTROS_COSTO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CENTROS_COSTORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CENTROS_COSTORow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private string _estado;
		private decimal _orden;
		private string _es_unidad_negocio;
		private decimal _centro_costo_grupo_id;
		private bool _centro_costo_grupo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CENTROS_COSTORow_Base"/> class.
		/// </summary>
		public CENTROS_COSTORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CENTROS_COSTORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.ES_UNIDAD_NEGOCIO != original.ES_UNIDAD_NEGOCIO) return true;
			if (this.IsCENTRO_COSTO_GRUPO_IDNull != original.IsCENTRO_COSTO_GRUPO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_GRUPO_IDNull && !original.IsCENTRO_COSTO_GRUPO_IDNull)
				if (this.CENTRO_COSTO_GRUPO_ID != original.CENTRO_COSTO_GRUPO_ID) return true;
			
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
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
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
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_UNIDAD_NEGOCIO</c> column value.
		/// </summary>
		/// <value>The <c>ES_UNIDAD_NEGOCIO</c> column value.</value>
		public string ES_UNIDAD_NEGOCIO
		{
			get { return _es_unidad_negocio; }
			set { _es_unidad_negocio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_GRUPO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_grupo_id;
			}
			set
			{
				_centro_costo_grupo_idNull = false;
				_centro_costo_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_GRUPO_IDNull
		{
			get { return _centro_costo_grupo_idNull; }
			set { _centro_costo_grupo_idNull = value; }
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
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@ES_UNIDAD_NEGOCIO=");
			dynStr.Append(ES_UNIDAD_NEGOCIO);
			dynStr.Append("@CBA@CENTRO_COSTO_GRUPO_ID=");
			dynStr.Append(IsCENTRO_COSTO_GRUPO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_GRUPO_ID);
			return dynStr.ToString();
		}
	} // End of CENTROS_COSTORow_Base class
} // End of namespace
