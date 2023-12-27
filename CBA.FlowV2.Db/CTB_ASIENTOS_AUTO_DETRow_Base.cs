// <fileinfo name="CTB_ASIENTOS_AUTO_DETRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_DETRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_AUTO_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_AUTO_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_DETRow_Base
	{
		private decimal _id;
		private decimal _ctb_asiento_automatico_id;
		private string _nombre;
		private string _descripcion;
		private decimal _orden;
		private decimal _columna_prioritaria;
		private bool _columna_prioritariaNull = true;
		private decimal _columna_prioritaria2;
		private bool _columna_prioritaria2Null = true;
		private string _resumir_detalles;
		private decimal _centro_costo_prioridad;
		private bool _centro_costo_prioridadNull = true;
		private decimal _centro_costo_prioridad2;
		private bool _centro_costo_prioridad2Null = true;
		private string _copiar_obs_cabecera_asiento;
		private decimal _centro_costo_prioridad3;
		private bool _centro_costo_prioridad3Null = true;
		private string _estructura_observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_DETRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_AUTO_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_AUTO_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTO_AUTOMATICO_ID != original.CTB_ASIENTO_AUTOMATICO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.IsCOLUMNA_PRIORITARIANull != original.IsCOLUMNA_PRIORITARIANull) return true;
			if (!this.IsCOLUMNA_PRIORITARIANull && !original.IsCOLUMNA_PRIORITARIANull)
				if (this.COLUMNA_PRIORITARIA != original.COLUMNA_PRIORITARIA) return true;
			if (this.IsCOLUMNA_PRIORITARIA2Null != original.IsCOLUMNA_PRIORITARIA2Null) return true;
			if (!this.IsCOLUMNA_PRIORITARIA2Null && !original.IsCOLUMNA_PRIORITARIA2Null)
				if (this.COLUMNA_PRIORITARIA2 != original.COLUMNA_PRIORITARIA2) return true;
			if (this.RESUMIR_DETALLES != original.RESUMIR_DETALLES) return true;
			if (this.IsCENTRO_COSTO_PRIORIDADNull != original.IsCENTRO_COSTO_PRIORIDADNull) return true;
			if (!this.IsCENTRO_COSTO_PRIORIDADNull && !original.IsCENTRO_COSTO_PRIORIDADNull)
				if (this.CENTRO_COSTO_PRIORIDAD != original.CENTRO_COSTO_PRIORIDAD) return true;
			if (this.IsCENTRO_COSTO_PRIORIDAD2Null != original.IsCENTRO_COSTO_PRIORIDAD2Null) return true;
			if (!this.IsCENTRO_COSTO_PRIORIDAD2Null && !original.IsCENTRO_COSTO_PRIORIDAD2Null)
				if (this.CENTRO_COSTO_PRIORIDAD2 != original.CENTRO_COSTO_PRIORIDAD2) return true;
			if (this.COPIAR_OBS_CABECERA_ASIENTO != original.COPIAR_OBS_CABECERA_ASIENTO) return true;
			if (this.IsCENTRO_COSTO_PRIORIDAD3Null != original.IsCENTRO_COSTO_PRIORIDAD3Null) return true;
			if (!this.IsCENTRO_COSTO_PRIORIDAD3Null && !original.IsCENTRO_COSTO_PRIORIDAD3Null)
				if (this.CENTRO_COSTO_PRIORIDAD3 != original.CENTRO_COSTO_PRIORIDAD3) return true;
			if (this.ESTRUCTURA_OBSERVACION != original.ESTRUCTURA_OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</value>
		public decimal CTB_ASIENTO_AUTOMATICO_ID
		{
			get { return _ctb_asiento_automatico_id; }
			set { _ctb_asiento_automatico_id = value; }
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
		/// Gets or sets the <c>COLUMNA_PRIORITARIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLUMNA_PRIORITARIA</c> column value.</value>
		public decimal COLUMNA_PRIORITARIA
		{
			get
			{
				if(IsCOLUMNA_PRIORITARIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _columna_prioritaria;
			}
			set
			{
				_columna_prioritariaNull = false;
				_columna_prioritaria = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COLUMNA_PRIORITARIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOLUMNA_PRIORITARIANull
		{
			get { return _columna_prioritariaNull; }
			set { _columna_prioritariaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLUMNA_PRIORITARIA2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLUMNA_PRIORITARIA2</c> column value.</value>
		public decimal COLUMNA_PRIORITARIA2
		{
			get
			{
				if(IsCOLUMNA_PRIORITARIA2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _columna_prioritaria2;
			}
			set
			{
				_columna_prioritaria2Null = false;
				_columna_prioritaria2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COLUMNA_PRIORITARIA2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOLUMNA_PRIORITARIA2Null
		{
			get { return _columna_prioritaria2Null; }
			set { _columna_prioritaria2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESUMIR_DETALLES</c> column value.
		/// </summary>
		/// <value>The <c>RESUMIR_DETALLES</c> column value.</value>
		public string RESUMIR_DETALLES
		{
			get { return _resumir_detalles; }
			set { _resumir_detalles = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_PRIORIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_PRIORIDAD</c> column value.</value>
		public decimal CENTRO_COSTO_PRIORIDAD
		{
			get
			{
				if(IsCENTRO_COSTO_PRIORIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_prioridad;
			}
			set
			{
				_centro_costo_prioridadNull = false;
				_centro_costo_prioridad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_PRIORIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_PRIORIDADNull
		{
			get { return _centro_costo_prioridadNull; }
			set { _centro_costo_prioridadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_PRIORIDAD2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_PRIORIDAD2</c> column value.</value>
		public decimal CENTRO_COSTO_PRIORIDAD2
		{
			get
			{
				if(IsCENTRO_COSTO_PRIORIDAD2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_prioridad2;
			}
			set
			{
				_centro_costo_prioridad2Null = false;
				_centro_costo_prioridad2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_PRIORIDAD2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_PRIORIDAD2Null
		{
			get { return _centro_costo_prioridad2Null; }
			set { _centro_costo_prioridad2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COPIAR_OBS_CABECERA_ASIENTO</c> column value.
		/// </summary>
		/// <value>The <c>COPIAR_OBS_CABECERA_ASIENTO</c> column value.</value>
		public string COPIAR_OBS_CABECERA_ASIENTO
		{
			get { return _copiar_obs_cabecera_asiento; }
			set { _copiar_obs_cabecera_asiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_PRIORIDAD3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_PRIORIDAD3</c> column value.</value>
		public decimal CENTRO_COSTO_PRIORIDAD3
		{
			get
			{
				if(IsCENTRO_COSTO_PRIORIDAD3Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_prioridad3;
			}
			set
			{
				_centro_costo_prioridad3Null = false;
				_centro_costo_prioridad3 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_PRIORIDAD3"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_PRIORIDAD3Null
		{
			get { return _centro_costo_prioridad3Null; }
			set { _centro_costo_prioridad3Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTRUCTURA_OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>ESTRUCTURA_OBSERVACION</c> column value.</value>
		public string ESTRUCTURA_OBSERVACION
		{
			get { return _estructura_observacion; }
			set { _estructura_observacion = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTO_AUTOMATICO_ID=");
			dynStr.Append(CTB_ASIENTO_AUTOMATICO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@COLUMNA_PRIORITARIA=");
			dynStr.Append(IsCOLUMNA_PRIORITARIANull ? (object)"<NULL>" : COLUMNA_PRIORITARIA);
			dynStr.Append("@CBA@COLUMNA_PRIORITARIA2=");
			dynStr.Append(IsCOLUMNA_PRIORITARIA2Null ? (object)"<NULL>" : COLUMNA_PRIORITARIA2);
			dynStr.Append("@CBA@RESUMIR_DETALLES=");
			dynStr.Append(RESUMIR_DETALLES);
			dynStr.Append("@CBA@CENTRO_COSTO_PRIORIDAD=");
			dynStr.Append(IsCENTRO_COSTO_PRIORIDADNull ? (object)"<NULL>" : CENTRO_COSTO_PRIORIDAD);
			dynStr.Append("@CBA@CENTRO_COSTO_PRIORIDAD2=");
			dynStr.Append(IsCENTRO_COSTO_PRIORIDAD2Null ? (object)"<NULL>" : CENTRO_COSTO_PRIORIDAD2);
			dynStr.Append("@CBA@COPIAR_OBS_CABECERA_ASIENTO=");
			dynStr.Append(COPIAR_OBS_CABECERA_ASIENTO);
			dynStr.Append("@CBA@CENTRO_COSTO_PRIORIDAD3=");
			dynStr.Append(IsCENTRO_COSTO_PRIORIDAD3Null ? (object)"<NULL>" : CENTRO_COSTO_PRIORIDAD3);
			dynStr.Append("@CBA@ESTRUCTURA_OBSERVACION=");
			dynStr.Append(ESTRUCTURA_OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_AUTO_DETRow_Base class
} // End of namespace
