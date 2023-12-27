// <fileinfo name="REPORTESRow_Base.cs">
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
	/// The base class for <see cref="REPORTESRow"/> that 
	/// represents a record in the <c>REPORTES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPORTESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPORTESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _nombre_fisico;
		private decimal _tipo_reporte_id;
		private string _estado;
		private string _mostrar_en_arbol;
		private string _recurso;
		private decimal _formato_reporte_id;
		private bool _formato_reporte_idNull = true;
		private string _impresion_silenciosa;
		private string _linkable;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTESRow_Base"/> class.
		/// </summary>
		public REPORTESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPORTESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.NOMBRE_FISICO != original.NOMBRE_FISICO) return true;
			if (this.TIPO_REPORTE_ID != original.TIPO_REPORTE_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.MOSTRAR_EN_ARBOL != original.MOSTRAR_EN_ARBOL) return true;
			if (this.RECURSO != original.RECURSO) return true;
			if (this.IsFORMATO_REPORTE_IDNull != original.IsFORMATO_REPORTE_IDNull) return true;
			if (!this.IsFORMATO_REPORTE_IDNull && !original.IsFORMATO_REPORTE_IDNull)
				if (this.FORMATO_REPORTE_ID != original.FORMATO_REPORTE_ID) return true;
			if (this.IMPRESION_SILENCIOSA != original.IMPRESION_SILENCIOSA) return true;
			if (this.LINKABLE != original.LINKABLE) return true;
			
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
		/// Gets or sets the <c>NOMBRE_FISICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_FISICO</c> column value.</value>
		public string NOMBRE_FISICO
		{
			get { return _nombre_fisico; }
			set { _nombre_fisico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_REPORTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_REPORTE_ID</c> column value.</value>
		public decimal TIPO_REPORTE_ID
		{
			get { return _tipo_reporte_id; }
			set { _tipo_reporte_id = value; }
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
		/// Gets or sets the <c>MOSTRAR_EN_ARBOL</c> column value.
		/// </summary>
		/// <value>The <c>MOSTRAR_EN_ARBOL</c> column value.</value>
		public string MOSTRAR_EN_ARBOL
		{
			get { return _mostrar_en_arbol; }
			set { _mostrar_en_arbol = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECURSO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECURSO</c> column value.</value>
		public string RECURSO
		{
			get { return _recurso; }
			set { _recurso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FORMATO_REPORTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FORMATO_REPORTE_ID</c> column value.</value>
		public decimal FORMATO_REPORTE_ID
		{
			get
			{
				if(IsFORMATO_REPORTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _formato_reporte_id;
			}
			set
			{
				_formato_reporte_idNull = false;
				_formato_reporte_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FORMATO_REPORTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFORMATO_REPORTE_IDNull
		{
			get { return _formato_reporte_idNull; }
			set { _formato_reporte_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESION_SILENCIOSA</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESION_SILENCIOSA</c> column value.</value>
		public string IMPRESION_SILENCIOSA
		{
			get { return _impresion_silenciosa; }
			set { _impresion_silenciosa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINKABLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINKABLE</c> column value.</value>
		public string LINKABLE
		{
			get { return _linkable; }
			set { _linkable = value; }
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
			dynStr.Append("@CBA@NOMBRE_FISICO=");
			dynStr.Append(NOMBRE_FISICO);
			dynStr.Append("@CBA@TIPO_REPORTE_ID=");
			dynStr.Append(TIPO_REPORTE_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MOSTRAR_EN_ARBOL=");
			dynStr.Append(MOSTRAR_EN_ARBOL);
			dynStr.Append("@CBA@RECURSO=");
			dynStr.Append(RECURSO);
			dynStr.Append("@CBA@FORMATO_REPORTE_ID=");
			dynStr.Append(IsFORMATO_REPORTE_IDNull ? (object)"<NULL>" : FORMATO_REPORTE_ID);
			dynStr.Append("@CBA@IMPRESION_SILENCIOSA=");
			dynStr.Append(IMPRESION_SILENCIOSA);
			dynStr.Append("@CBA@LINKABLE=");
			dynStr.Append(LINKABLE);
			return dynStr.ToString();
		}
	} // End of REPORTESRow_Base class
} // End of namespace
