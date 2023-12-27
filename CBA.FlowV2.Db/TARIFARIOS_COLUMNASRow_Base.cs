// <fileinfo name="TARIFARIOS_COLUMNASRow_Base.cs">
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
	/// The base class for <see cref="TARIFARIOS_COLUMNASRow"/> that 
	/// represents a record in the <c>TARIFARIOS_COLUMNAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TARIFARIOS_COLUMNASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TARIFARIOS_COLUMNASRow_Base
	{
		private decimal _id;
		private decimal _tarifario_id;
		private string _nombre;
		private decimal _tipo_dato_id;
		private string _estado;
		private decimal _usuario_modificacion_id;
		private System.DateTime _fecha_modificacion;
		private string _obligatorio;
		private decimal _orden;
		private decimal _articulo_relacionado_id;
		private bool _articulo_relacionado_idNull = true;
		private decimal _tarifarios_grupo_id;
		private bool _tarifarios_grupo_idNull = true;
		private decimal _minimo;
		private bool _minimoNull = true;
		private decimal _maximo;
		private bool _maximoNull = true;
		private decimal _valor_por_defecto;
		private bool _valor_por_defectoNull = true;
		private string _incluir_siempre;
		private string _tomar_dato_ingresado;
		private decimal _primer_periodo;
		private bool _primer_periodoNull = true;
		private decimal _periodos_posteriores;
		private bool _periodos_posterioresNull = true;
		private decimal _prorrateo_periodos;
		private bool _prorrateo_periodosNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_COLUMNASRow_Base"/> class.
		/// </summary>
		public TARIFARIOS_COLUMNASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TARIFARIOS_COLUMNASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TARIFARIO_ID != original.TARIFARIO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.TIPO_DATO_ID != original.TIPO_DATO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.USUARIO_MODIFICACION_ID != original.USUARIO_MODIFICACION_ID) return true;
			if (this.FECHA_MODIFICACION != original.FECHA_MODIFICACION) return true;
			if (this.OBLIGATORIO != original.OBLIGATORIO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.IsARTICULO_RELACIONADO_IDNull != original.IsARTICULO_RELACIONADO_IDNull) return true;
			if (!this.IsARTICULO_RELACIONADO_IDNull && !original.IsARTICULO_RELACIONADO_IDNull)
				if (this.ARTICULO_RELACIONADO_ID != original.ARTICULO_RELACIONADO_ID) return true;
			if (this.IsTARIFARIOS_GRUPO_IDNull != original.IsTARIFARIOS_GRUPO_IDNull) return true;
			if (!this.IsTARIFARIOS_GRUPO_IDNull && !original.IsTARIFARIOS_GRUPO_IDNull)
				if (this.TARIFARIOS_GRUPO_ID != original.TARIFARIOS_GRUPO_ID) return true;
			if (this.IsMINIMONull != original.IsMINIMONull) return true;
			if (!this.IsMINIMONull && !original.IsMINIMONull)
				if (this.MINIMO != original.MINIMO) return true;
			if (this.IsMAXIMONull != original.IsMAXIMONull) return true;
			if (!this.IsMAXIMONull && !original.IsMAXIMONull)
				if (this.MAXIMO != original.MAXIMO) return true;
			if (this.IsVALOR_POR_DEFECTONull != original.IsVALOR_POR_DEFECTONull) return true;
			if (!this.IsVALOR_POR_DEFECTONull && !original.IsVALOR_POR_DEFECTONull)
				if (this.VALOR_POR_DEFECTO != original.VALOR_POR_DEFECTO) return true;
			if (this.INCLUIR_SIEMPRE != original.INCLUIR_SIEMPRE) return true;
			if (this.TOMAR_DATO_INGRESADO != original.TOMAR_DATO_INGRESADO) return true;
			if (this.IsPRIMER_PERIODONull != original.IsPRIMER_PERIODONull) return true;
			if (!this.IsPRIMER_PERIODONull && !original.IsPRIMER_PERIODONull)
				if (this.PRIMER_PERIODO != original.PRIMER_PERIODO) return true;
			if (this.IsPERIODOS_POSTERIORESNull != original.IsPERIODOS_POSTERIORESNull) return true;
			if (!this.IsPERIODOS_POSTERIORESNull && !original.IsPERIODOS_POSTERIORESNull)
				if (this.PERIODOS_POSTERIORES != original.PERIODOS_POSTERIORES) return true;
			if (this.IsPRORRATEO_PERIODOSNull != original.IsPRORRATEO_PERIODOSNull) return true;
			if (!this.IsPRORRATEO_PERIODOSNull && !original.IsPRORRATEO_PERIODOSNull)
				if (this.PRORRATEO_PERIODOS != original.PRORRATEO_PERIODOS) return true;
			
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
		/// Gets or sets the <c>TARIFARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TARIFARIO_ID</c> column value.</value>
		public decimal TARIFARIO_ID
		{
			get { return _tarifario_id; }
			set { _tarifario_id = value; }
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
		/// Gets or sets the <c>TIPO_DATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DATO_ID</c> column value.</value>
		public decimal TIPO_DATO_ID
		{
			get { return _tipo_dato_id; }
			set { _tipo_dato_id = value; }
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
		/// Gets or sets the <c>USUARIO_MODIFICACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_ID</c> column value.</value>
		public decimal USUARIO_MODIFICACION_ID
		{
			get { return _usuario_modificacion_id; }
			set { _usuario_modificacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MODIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MODIFICACION</c> column value.</value>
		public System.DateTime FECHA_MODIFICACION
		{
			get { return _fecha_modificacion; }
			set { _fecha_modificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>OBLIGATORIO</c> column value.</value>
		public string OBLIGATORIO
		{
			get { return _obligatorio; }
			set { _obligatorio = value; }
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
		/// Gets or sets the <c>ARTICULO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_RELACIONADO_ID</c> column value.</value>
		public decimal ARTICULO_RELACIONADO_ID
		{
			get
			{
				if(IsARTICULO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_relacionado_id;
			}
			set
			{
				_articulo_relacionado_idNull = false;
				_articulo_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_RELACIONADO_IDNull
		{
			get { return _articulo_relacionado_idNull; }
			set { _articulo_relacionado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARIFARIOS_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARIFARIOS_GRUPO_ID</c> column value.</value>
		public decimal TARIFARIOS_GRUPO_ID
		{
			get
			{
				if(IsTARIFARIOS_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tarifarios_grupo_id;
			}
			set
			{
				_tarifarios_grupo_idNull = false;
				_tarifarios_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARIFARIOS_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARIFARIOS_GRUPO_IDNull
		{
			get { return _tarifarios_grupo_idNull; }
			set { _tarifarios_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MINIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MINIMO</c> column value.</value>
		public decimal MINIMO
		{
			get
			{
				if(IsMINIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _minimo;
			}
			set
			{
				_minimoNull = false;
				_minimo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MINIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMINIMONull
		{
			get { return _minimoNull; }
			set { _minimoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MAXIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MAXIMO</c> column value.</value>
		public decimal MAXIMO
		{
			get
			{
				if(IsMAXIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _maximo;
			}
			set
			{
				_maximoNull = false;
				_maximo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MAXIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMAXIMONull
		{
			get { return _maximoNull; }
			set { _maximoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_POR_DEFECTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_POR_DEFECTO</c> column value.</value>
		public decimal VALOR_POR_DEFECTO
		{
			get
			{
				if(IsVALOR_POR_DEFECTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_por_defecto;
			}
			set
			{
				_valor_por_defectoNull = false;
				_valor_por_defecto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_POR_DEFECTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_POR_DEFECTONull
		{
			get { return _valor_por_defectoNull; }
			set { _valor_por_defectoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUIR_SIEMPRE</c> column value.
		/// </summary>
		/// <value>The <c>INCLUIR_SIEMPRE</c> column value.</value>
		public string INCLUIR_SIEMPRE
		{
			get { return _incluir_siempre; }
			set { _incluir_siempre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOMAR_DATO_INGRESADO</c> column value.
		/// </summary>
		/// <value>The <c>TOMAR_DATO_INGRESADO</c> column value.</value>
		public string TOMAR_DATO_INGRESADO
		{
			get { return _tomar_dato_ingresado; }
			set { _tomar_dato_ingresado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRIMER_PERIODO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRIMER_PERIODO</c> column value.</value>
		public decimal PRIMER_PERIODO
		{
			get
			{
				if(IsPRIMER_PERIODONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _primer_periodo;
			}
			set
			{
				_primer_periodoNull = false;
				_primer_periodo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRIMER_PERIODO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRIMER_PERIODONull
		{
			get { return _primer_periodoNull; }
			set { _primer_periodoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERIODOS_POSTERIORES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERIODOS_POSTERIORES</c> column value.</value>
		public decimal PERIODOS_POSTERIORES
		{
			get
			{
				if(IsPERIODOS_POSTERIORESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _periodos_posteriores;
			}
			set
			{
				_periodos_posterioresNull = false;
				_periodos_posteriores = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERIODOS_POSTERIORES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERIODOS_POSTERIORESNull
		{
			get { return _periodos_posterioresNull; }
			set { _periodos_posterioresNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRORRATEO_PERIODOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRORRATEO_PERIODOS</c> column value.</value>
		public decimal PRORRATEO_PERIODOS
		{
			get
			{
				if(IsPRORRATEO_PERIODOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _prorrateo_periodos;
			}
			set
			{
				_prorrateo_periodosNull = false;
				_prorrateo_periodos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRORRATEO_PERIODOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRORRATEO_PERIODOSNull
		{
			get { return _prorrateo_periodosNull; }
			set { _prorrateo_periodosNull = value; }
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
			dynStr.Append("@CBA@TARIFARIO_ID=");
			dynStr.Append(TARIFARIO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@TIPO_DATO_ID=");
			dynStr.Append(TIPO_DATO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_ID=");
			dynStr.Append(USUARIO_MODIFICACION_ID);
			dynStr.Append("@CBA@FECHA_MODIFICACION=");
			dynStr.Append(FECHA_MODIFICACION);
			dynStr.Append("@CBA@OBLIGATORIO=");
			dynStr.Append(OBLIGATORIO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@ARTICULO_RELACIONADO_ID=");
			dynStr.Append(IsARTICULO_RELACIONADO_IDNull ? (object)"<NULL>" : ARTICULO_RELACIONADO_ID);
			dynStr.Append("@CBA@TARIFARIOS_GRUPO_ID=");
			dynStr.Append(IsTARIFARIOS_GRUPO_IDNull ? (object)"<NULL>" : TARIFARIOS_GRUPO_ID);
			dynStr.Append("@CBA@MINIMO=");
			dynStr.Append(IsMINIMONull ? (object)"<NULL>" : MINIMO);
			dynStr.Append("@CBA@MAXIMO=");
			dynStr.Append(IsMAXIMONull ? (object)"<NULL>" : MAXIMO);
			dynStr.Append("@CBA@VALOR_POR_DEFECTO=");
			dynStr.Append(IsVALOR_POR_DEFECTONull ? (object)"<NULL>" : VALOR_POR_DEFECTO);
			dynStr.Append("@CBA@INCLUIR_SIEMPRE=");
			dynStr.Append(INCLUIR_SIEMPRE);
			dynStr.Append("@CBA@TOMAR_DATO_INGRESADO=");
			dynStr.Append(TOMAR_DATO_INGRESADO);
			dynStr.Append("@CBA@PRIMER_PERIODO=");
			dynStr.Append(IsPRIMER_PERIODONull ? (object)"<NULL>" : PRIMER_PERIODO);
			dynStr.Append("@CBA@PERIODOS_POSTERIORES=");
			dynStr.Append(IsPERIODOS_POSTERIORESNull ? (object)"<NULL>" : PERIODOS_POSTERIORES);
			dynStr.Append("@CBA@PRORRATEO_PERIODOS=");
			dynStr.Append(IsPRORRATEO_PERIODOSNull ? (object)"<NULL>" : PRORRATEO_PERIODOS);
			return dynStr.ToString();
		}
	} // End of TARIFARIOS_COLUMNASRow_Base class
} // End of namespace
