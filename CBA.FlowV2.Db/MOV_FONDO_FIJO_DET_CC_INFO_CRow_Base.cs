// <fileinfo name="MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="MOV_FONDO_FIJO_DET_CC_INFO_CRow"/> that 
	/// represents a record in the <c>MOV_FONDO_FIJO_DET_CC_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MOV_FONDO_FIJO_DET_CC_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _movimiento_fondo_fijo_det_id;
		private bool _movimiento_fondo_fijo_det_idNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private string _centro_costo_nombre;
		private string _centro_costo_abreviatura;
		private decimal _centro_costo_orden;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base"/> class.
		/// </summary>
		public MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull != original.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull) return true;
			if (!this.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull && !original.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull)
				if (this.MOVIMIENTO_FONDO_FIJO_DET_ID != original.MOVIMIENTO_FONDO_FIJO_DET_ID) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.CENTRO_COSTO_NOMBRE != original.CENTRO_COSTO_NOMBRE) return true;
			if (this.CENTRO_COSTO_ABREVIATURA != original.CENTRO_COSTO_ABREVIATURA) return true;
			if (this.CENTRO_COSTO_ORDEN != original.CENTRO_COSTO_ORDEN) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</value>
		public decimal MOVIMIENTO_FONDO_FIJO_DET_ID
		{
			get
			{
				if(IsMOVIMIENTO_FONDO_FIJO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_fondo_fijo_det_id;
			}
			set
			{
				_movimiento_fondo_fijo_det_idNull = false;
				_movimiento_fondo_fijo_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_FONDO_FIJO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_FONDO_FIJO_DET_IDNull
		{
			get { return _movimiento_fondo_fijo_det_idNull; }
			set { _movimiento_fondo_fijo_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
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
		/// Gets or sets the <c>CENTRO_COSTO_ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ORDEN</c> column value.</value>
		public decimal CENTRO_COSTO_ORDEN
		{
			get { return _centro_costo_orden; }
			set { _centro_costo_orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@MOVIMIENTO_FONDO_FIJO_DET_ID=");
			dynStr.Append(IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? (object)"<NULL>" : MOVIMIENTO_FONDO_FIJO_DET_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_NOMBRE=");
			dynStr.Append(CENTRO_COSTO_NOMBRE);
			dynStr.Append("@CBA@CENTRO_COSTO_ABREVIATURA=");
			dynStr.Append(CENTRO_COSTO_ABREVIATURA);
			dynStr.Append("@CBA@CENTRO_COSTO_ORDEN=");
			dynStr.Append(CENTRO_COSTO_ORDEN);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of MOV_FONDO_FIJO_DET_CC_INFO_CRow_Base class
} // End of namespace
