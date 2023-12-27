// <fileinfo name="PLANILLAS_LIQ_DESCUENTOSRow_Base.cs">
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
	/// The base class for <see cref="PLANILLAS_LIQ_DESCUENTOSRow"/> that 
	/// represents a record in the <c>PLANILLAS_LIQ_DESCUENTOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLAS_LIQ_DESCUENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLAS_LIQ_DESCUENTOSRow_Base
	{
		private decimal _montodescuento;
		private bool _montodescuentoNull = true;
		private decimal _detalle_id;
		private decimal _liquidacion_id;
		private bool _liquidacion_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _nombre_descuento;
		private decimal _planilla_liq_id;
		private bool _planilla_liq_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLAS_LIQ_DESCUENTOSRow_Base"/> class.
		/// </summary>
		public PLANILLAS_LIQ_DESCUENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLAS_LIQ_DESCUENTOSRow_Base original)
		{
			if (this.IsMONTODESCUENTONull != original.IsMONTODESCUENTONull) return true;
			if (!this.IsMONTODESCUENTONull && !original.IsMONTODESCUENTONull)
				if (this.MONTODESCUENTO != original.MONTODESCUENTO) return true;
			if (this.DETALLE_ID != original.DETALLE_ID) return true;
			if (this.IsLIQUIDACION_IDNull != original.IsLIQUIDACION_IDNull) return true;
			if (!this.IsLIQUIDACION_IDNull && !original.IsLIQUIDACION_IDNull)
				if (this.LIQUIDACION_ID != original.LIQUIDACION_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.NOMBRE_DESCUENTO != original.NOMBRE_DESCUENTO) return true;
			if (this.IsPLANILLA_LIQ_IDNull != original.IsPLANILLA_LIQ_IDNull) return true;
			if (!this.IsPLANILLA_LIQ_IDNull && !original.IsPLANILLA_LIQ_IDNull)
				if (this.PLANILLA_LIQ_ID != original.PLANILLA_LIQ_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTODESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTODESCUENTO</c> column value.</value>
		public decimal MONTODESCUENTO
		{
			get
			{
				if(IsMONTODESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _montodescuento;
			}
			set
			{
				_montodescuentoNull = false;
				_montodescuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTODESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTODESCUENTONull
		{
			get { return _montodescuentoNull; }
			set { _montodescuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>DETALLE_ID</c> column value.</value>
		public decimal DETALLE_ID
		{
			get { return _detalle_id; }
			set { _detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIQUIDACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ID</c> column value.</value>
		public decimal LIQUIDACION_ID
		{
			get
			{
				if(IsLIQUIDACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_id;
			}
			set
			{
				_liquidacion_idNull = false;
				_liquidacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_IDNull
		{
			get { return _liquidacion_idNull; }
			set { _liquidacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_DESCUENTO</c> column value.</value>
		public string NOMBRE_DESCUENTO
		{
			get { return _nombre_descuento; }
			set { _nombre_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_LIQ_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANILLA_LIQ_ID</c> column value.</value>
		public decimal PLANILLA_LIQ_ID
		{
			get
			{
				if(IsPLANILLA_LIQ_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _planilla_liq_id;
			}
			set
			{
				_planilla_liq_idNull = false;
				_planilla_liq_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLANILLA_LIQ_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLANILLA_LIQ_IDNull
		{
			get { return _planilla_liq_idNull; }
			set { _planilla_liq_idNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@MONTODESCUENTO=");
			dynStr.Append(IsMONTODESCUENTONull ? (object)"<NULL>" : MONTODESCUENTO);
			dynStr.Append("@CBA@DETALLE_ID=");
			dynStr.Append(DETALLE_ID);
			dynStr.Append("@CBA@LIQUIDACION_ID=");
			dynStr.Append(IsLIQUIDACION_IDNull ? (object)"<NULL>" : LIQUIDACION_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@NOMBRE_DESCUENTO=");
			dynStr.Append(NOMBRE_DESCUENTO);
			dynStr.Append("@CBA@PLANILLA_LIQ_ID=");
			dynStr.Append(IsPLANILLA_LIQ_IDNull ? (object)"<NULL>" : PLANILLA_LIQ_ID);
			return dynStr.ToString();
		}
	} // End of PLANILLAS_LIQ_DESCUENTOSRow_Base class
} // End of namespace
