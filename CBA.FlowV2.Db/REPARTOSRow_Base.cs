// <fileinfo name="REPARTOSRow_Base.cs">
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
	/// The base class for <see cref="REPARTOSRow"/> that 
	/// represents a record in the <c>REPARTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPARTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private decimal _funcionario_chofer_id;
		private bool _funcionario_chofer_idNull = true;
		private decimal _funcionario_acompanhante_1;
		private bool _funcionario_acompanhante_1Null = true;
		private decimal _funcionario_acompanhante_2;
		private bool _funcionario_acompanhante_2Null = true;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private System.DateTime _fecha_regreso;
		private bool _fecha_regresoNull = true;
		private decimal _kilometraje_salida;
		private bool _kilometraje_salidaNull = true;
		private decimal _kilometraje_regreso;
		private bool _kilometraje_regresoNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _observacion;
		private string _impreso;
		private decimal _ctacte_caja_suc_id;
		private bool _ctacte_caja_suc_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTOSRow_Base"/> class.
		/// </summary>
		public REPARTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPARTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.IsFUNCIONARIO_CHOFER_IDNull != original.IsFUNCIONARIO_CHOFER_IDNull) return true;
			if (!this.IsFUNCIONARIO_CHOFER_IDNull && !original.IsFUNCIONARIO_CHOFER_IDNull)
				if (this.FUNCIONARIO_CHOFER_ID != original.FUNCIONARIO_CHOFER_ID) return true;
			if (this.IsFUNCIONARIO_ACOMPANHANTE_1Null != original.IsFUNCIONARIO_ACOMPANHANTE_1Null) return true;
			if (!this.IsFUNCIONARIO_ACOMPANHANTE_1Null && !original.IsFUNCIONARIO_ACOMPANHANTE_1Null)
				if (this.FUNCIONARIO_ACOMPANHANTE_1 != original.FUNCIONARIO_ACOMPANHANTE_1) return true;
			if (this.IsFUNCIONARIO_ACOMPANHANTE_2Null != original.IsFUNCIONARIO_ACOMPANHANTE_2Null) return true;
			if (!this.IsFUNCIONARIO_ACOMPANHANTE_2Null && !original.IsFUNCIONARIO_ACOMPANHANTE_2Null)
				if (this.FUNCIONARIO_ACOMPANHANTE_2 != original.FUNCIONARIO_ACOMPANHANTE_2) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.IsFECHA_REGRESONull != original.IsFECHA_REGRESONull) return true;
			if (!this.IsFECHA_REGRESONull && !original.IsFECHA_REGRESONull)
				if (this.FECHA_REGRESO != original.FECHA_REGRESO) return true;
			if (this.IsKILOMETRAJE_SALIDANull != original.IsKILOMETRAJE_SALIDANull) return true;
			if (!this.IsKILOMETRAJE_SALIDANull && !original.IsKILOMETRAJE_SALIDANull)
				if (this.KILOMETRAJE_SALIDA != original.KILOMETRAJE_SALIDA) return true;
			if (this.IsKILOMETRAJE_REGRESONull != original.IsKILOMETRAJE_REGRESONull) return true;
			if (!this.IsKILOMETRAJE_REGRESONull && !original.IsKILOMETRAJE_REGRESONull)
				if (this.KILOMETRAJE_REGRESO != original.KILOMETRAJE_REGRESO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			if (this.IsCTACTE_CAJA_SUC_IDNull != original.IsCTACTE_CAJA_SUC_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUC_IDNull && !original.IsCTACTE_CAJA_SUC_IDNull)
				if (this.CTACTE_CAJA_SUC_ID != original.CTACTE_CAJA_SUC_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VEHICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_ID</c> column value.</value>
		public decimal VEHICULO_ID
		{
			get
			{
				if(IsVEHICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vehiculo_id;
			}
			set
			{
				_vehiculo_idNull = false;
				_vehiculo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VEHICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVEHICULO_IDNull
		{
			get { return _vehiculo_idNull; }
			set { _vehiculo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CHOFER_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CHOFER_ID</c> column value.</value>
		public decimal FUNCIONARIO_CHOFER_ID
		{
			get
			{
				if(IsFUNCIONARIO_CHOFER_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_chofer_id;
			}
			set
			{
				_funcionario_chofer_idNull = false;
				_funcionario_chofer_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_CHOFER_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_CHOFER_IDNull
		{
			get { return _funcionario_chofer_idNull; }
			set { _funcionario_chofer_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</value>
		public decimal FUNCIONARIO_ACOMPANHANTE_1
		{
			get
			{
				if(IsFUNCIONARIO_ACOMPANHANTE_1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_acompanhante_1;
			}
			set
			{
				_funcionario_acompanhante_1Null = false;
				_funcionario_acompanhante_1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ACOMPANHANTE_1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ACOMPANHANTE_1Null
		{
			get { return _funcionario_acompanhante_1Null; }
			set { _funcionario_acompanhante_1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</value>
		public decimal FUNCIONARIO_ACOMPANHANTE_2
		{
			get
			{
				if(IsFUNCIONARIO_ACOMPANHANTE_2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_acompanhante_2;
			}
			set
			{
				_funcionario_acompanhante_2Null = false;
				_funcionario_acompanhante_2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ACOMPANHANTE_2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ACOMPANHANTE_2Null
		{
			get { return _funcionario_acompanhante_2Null; }
			set { _funcionario_acompanhante_2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_REGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_REGRESO</c> column value.</value>
		public System.DateTime FECHA_REGRESO
		{
			get
			{
				if(IsFECHA_REGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_regreso;
			}
			set
			{
				_fecha_regresoNull = false;
				_fecha_regreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_REGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_REGRESONull
		{
			get { return _fecha_regresoNull; }
			set { _fecha_regresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>KILOMETRAJE_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>KILOMETRAJE_SALIDA</c> column value.</value>
		public decimal KILOMETRAJE_SALIDA
		{
			get
			{
				if(IsKILOMETRAJE_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _kilometraje_salida;
			}
			set
			{
				_kilometraje_salidaNull = false;
				_kilometraje_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="KILOMETRAJE_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsKILOMETRAJE_SALIDANull
		{
			get { return _kilometraje_salidaNull; }
			set { _kilometraje_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>KILOMETRAJE_REGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>KILOMETRAJE_REGRESO</c> column value.</value>
		public decimal KILOMETRAJE_REGRESO
		{
			get
			{
				if(IsKILOMETRAJE_REGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _kilometraje_regreso;
			}
			set
			{
				_kilometraje_regresoNull = false;
				_kilometraje_regreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="KILOMETRAJE_REGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsKILOMETRAJE_REGRESONull
		{
			get { return _kilometraje_regresoNull; }
			set { _kilometraje_regresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUC_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_suc_id;
			}
			set
			{
				_ctacte_caja_suc_idNull = false;
				_ctacte_caja_suc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUC_IDNull
		{
			get { return _ctacte_caja_suc_idNull; }
			set { _ctacte_caja_suc_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_CHOFER_ID=");
			dynStr.Append(IsFUNCIONARIO_CHOFER_IDNull ? (object)"<NULL>" : FUNCIONARIO_CHOFER_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ACOMPANHANTE_1=");
			dynStr.Append(IsFUNCIONARIO_ACOMPANHANTE_1Null ? (object)"<NULL>" : FUNCIONARIO_ACOMPANHANTE_1);
			dynStr.Append("@CBA@FUNCIONARIO_ACOMPANHANTE_2=");
			dynStr.Append(IsFUNCIONARIO_ACOMPANHANTE_2Null ? (object)"<NULL>" : FUNCIONARIO_ACOMPANHANTE_2);
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@FECHA_REGRESO=");
			dynStr.Append(IsFECHA_REGRESONull ? (object)"<NULL>" : FECHA_REGRESO);
			dynStr.Append("@CBA@KILOMETRAJE_SALIDA=");
			dynStr.Append(IsKILOMETRAJE_SALIDANull ? (object)"<NULL>" : KILOMETRAJE_SALIDA);
			dynStr.Append("@CBA@KILOMETRAJE_REGRESO=");
			dynStr.Append(IsKILOMETRAJE_REGRESONull ? (object)"<NULL>" : KILOMETRAJE_REGRESO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUC_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUC_ID);
			return dynStr.ToString();
		}
	} // End of REPARTOSRow_Base class
} // End of namespace
