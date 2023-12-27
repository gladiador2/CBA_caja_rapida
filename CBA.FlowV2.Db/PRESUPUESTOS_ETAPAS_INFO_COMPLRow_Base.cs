// <fileinfo name="PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_ETAPAS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PRESUPUESTOS_ETAPAS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOS_ETAPAS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _presupuesto_id;
		private string _presupuesto_objeto;
		private decimal _presupuesto_caso_id;
		private decimal _entidad_id;
		private string _nombre;
		private System.DateTime _fecha_estimada_inicio;
		private bool _fecha_estimada_inicioNull = true;
		private System.DateTime _fecha_estimada_fin;
		private bool _fecha_estimada_finNull = true;
		private decimal _funcionario_responsable_id;
		private string _funcionario_nombre_completo;
		private decimal _orden;
		private decimal _total_monto_bruto;
		private bool _total_monto_brutoNull = true;
		private decimal _total_monto_descuento;
		private bool _total_monto_descuentoNull = true;
		private decimal _total_monto_neto;
		private bool _total_monto_netoNull = true;
		private decimal _total_monto_impuesto;
		private bool _total_monto_impuestoNull = true;
		private decimal _mora_porcentaje;
		private decimal _mora_dias_gracia;
		private decimal _articulo_porcentaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRESUPUESTO_ID != original.PRESUPUESTO_ID) return true;
			if (this.PRESUPUESTO_OBJETO != original.PRESUPUESTO_OBJETO) return true;
			if (this.PRESUPUESTO_CASO_ID != original.PRESUPUESTO_CASO_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsFECHA_ESTIMADA_INICIONull != original.IsFECHA_ESTIMADA_INICIONull) return true;
			if (!this.IsFECHA_ESTIMADA_INICIONull && !original.IsFECHA_ESTIMADA_INICIONull)
				if (this.FECHA_ESTIMADA_INICIO != original.FECHA_ESTIMADA_INICIO) return true;
			if (this.IsFECHA_ESTIMADA_FINNull != original.IsFECHA_ESTIMADA_FINNull) return true;
			if (!this.IsFECHA_ESTIMADA_FINNull && !original.IsFECHA_ESTIMADA_FINNull)
				if (this.FECHA_ESTIMADA_FIN != original.FECHA_ESTIMADA_FIN) return true;
			if (this.FUNCIONARIO_RESPONSABLE_ID != original.FUNCIONARIO_RESPONSABLE_ID) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.IsTOTAL_MONTO_BRUTONull != original.IsTOTAL_MONTO_BRUTONull) return true;
			if (!this.IsTOTAL_MONTO_BRUTONull && !original.IsTOTAL_MONTO_BRUTONull)
				if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.IsTOTAL_MONTO_DESCUENTONull != original.IsTOTAL_MONTO_DESCUENTONull) return true;
			if (!this.IsTOTAL_MONTO_DESCUENTONull && !original.IsTOTAL_MONTO_DESCUENTONull)
				if (this.TOTAL_MONTO_DESCUENTO != original.TOTAL_MONTO_DESCUENTO) return true;
			if (this.IsTOTAL_MONTO_NETONull != original.IsTOTAL_MONTO_NETONull) return true;
			if (!this.IsTOTAL_MONTO_NETONull && !original.IsTOTAL_MONTO_NETONull)
				if (this.TOTAL_MONTO_NETO != original.TOTAL_MONTO_NETO) return true;
			if (this.IsTOTAL_MONTO_IMPUESTONull != original.IsTOTAL_MONTO_IMPUESTONull) return true;
			if (!this.IsTOTAL_MONTO_IMPUESTONull && !original.IsTOTAL_MONTO_IMPUESTONull)
				if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.MORA_PORCENTAJE != original.MORA_PORCENTAJE) return true;
			if (this.MORA_DIAS_GRACIA != original.MORA_DIAS_GRACIA) return true;
			if (this.ARTICULO_PORCENTAJE != original.ARTICULO_PORCENTAJE) return true;
			
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
		/// Gets or sets the <c>PRESUPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ID</c> column value.</value>
		public decimal PRESUPUESTO_ID
		{
			get { return _presupuesto_id; }
			set { _presupuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_OBJETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_OBJETO</c> column value.</value>
		public string PRESUPUESTO_OBJETO
		{
			get { return _presupuesto_objeto; }
			set { _presupuesto_objeto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_CASO_ID</c> column value.</value>
		public decimal PRESUPUESTO_CASO_ID
		{
			get { return _presupuesto_caso_id; }
			set { _presupuesto_caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>FECHA_ESTIMADA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ESTIMADA_INICIO</c> column value.</value>
		public System.DateTime FECHA_ESTIMADA_INICIO
		{
			get
			{
				if(IsFECHA_ESTIMADA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_estimada_inicio;
			}
			set
			{
				_fecha_estimada_inicioNull = false;
				_fecha_estimada_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ESTIMADA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ESTIMADA_INICIONull
		{
			get { return _fecha_estimada_inicioNull; }
			set { _fecha_estimada_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ESTIMADA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ESTIMADA_FIN</c> column value.</value>
		public System.DateTime FECHA_ESTIMADA_FIN
		{
			get
			{
				if(IsFECHA_ESTIMADA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_estimada_fin;
			}
			set
			{
				_fecha_estimada_finNull = false;
				_fecha_estimada_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ESTIMADA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ESTIMADA_FINNull
		{
			get { return _fecha_estimada_finNull; }
			set { _fecha_estimada_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</value>
		public decimal FUNCIONARIO_RESPONSABLE_ID
		{
			get { return _funcionario_responsable_id; }
			set { _funcionario_responsable_id = value; }
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
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto;
			}
			set
			{
				_total_monto_brutoNull = false;
				_total_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTONull
		{
			get { return _total_monto_brutoNull; }
			set { _total_monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DESCUENTO</c> column value.</value>
		public decimal TOTAL_MONTO_DESCUENTO
		{
			get
			{
				if(IsTOTAL_MONTO_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_descuento;
			}
			set
			{
				_total_monto_descuentoNull = false;
				_total_monto_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_DESCUENTONull
		{
			get { return _total_monto_descuentoNull; }
			set { _total_monto_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_NETO</c> column value.</value>
		public decimal TOTAL_MONTO_NETO
		{
			get
			{
				if(IsTOTAL_MONTO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_neto;
			}
			set
			{
				_total_monto_netoNull = false;
				_total_monto_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_NETONull
		{
			get { return _total_monto_netoNull; }
			set { _total_monto_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get
			{
				if(IsTOTAL_MONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_impuesto;
			}
			set
			{
				_total_monto_impuestoNull = false;
				_total_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_IMPUESTONull
		{
			get { return _total_monto_impuestoNull; }
			set { _total_monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>MORA_PORCENTAJE</c> column value.</value>
		public decimal MORA_PORCENTAJE
		{
			get { return _mora_porcentaje; }
			set { _mora_porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_DIAS_GRACIA</c> column value.
		/// </summary>
		/// <value>The <c>MORA_DIAS_GRACIA</c> column value.</value>
		public decimal MORA_DIAS_GRACIA
		{
			get { return _mora_dias_gracia; }
			set { _mora_dias_gracia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_PORCENTAJE</c> column value.</value>
		public decimal ARTICULO_PORCENTAJE
		{
			get { return _articulo_porcentaje; }
			set { _articulo_porcentaje = value; }
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
			dynStr.Append("@CBA@PRESUPUESTO_ID=");
			dynStr.Append(PRESUPUESTO_ID);
			dynStr.Append("@CBA@PRESUPUESTO_OBJETO=");
			dynStr.Append(PRESUPUESTO_OBJETO);
			dynStr.Append("@CBA@PRESUPUESTO_CASO_ID=");
			dynStr.Append(PRESUPUESTO_CASO_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@FECHA_ESTIMADA_INICIO=");
			dynStr.Append(IsFECHA_ESTIMADA_INICIONull ? (object)"<NULL>" : FECHA_ESTIMADA_INICIO);
			dynStr.Append("@CBA@FECHA_ESTIMADA_FIN=");
			dynStr.Append(IsFECHA_ESTIMADA_FINNull ? (object)"<NULL>" : FECHA_ESTIMADA_FIN);
			dynStr.Append("@CBA@FUNCIONARIO_RESPONSABLE_ID=");
			dynStr.Append(FUNCIONARIO_RESPONSABLE_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(IsTOTAL_MONTO_BRUTONull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DESCUENTO=");
			dynStr.Append(IsTOTAL_MONTO_DESCUENTONull ? (object)"<NULL>" : TOTAL_MONTO_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_MONTO_NETO=");
			dynStr.Append(IsTOTAL_MONTO_NETONull ? (object)"<NULL>" : TOTAL_MONTO_NETO);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(IsTOTAL_MONTO_IMPUESTONull ? (object)"<NULL>" : TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@MORA_PORCENTAJE=");
			dynStr.Append(MORA_PORCENTAJE);
			dynStr.Append("@CBA@MORA_DIAS_GRACIA=");
			dynStr.Append(MORA_DIAS_GRACIA);
			dynStr.Append("@CBA@ARTICULO_PORCENTAJE=");
			dynStr.Append(ARTICULO_PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOS_ETAPAS_INFO_COMPLRow_Base class
} // End of namespace
