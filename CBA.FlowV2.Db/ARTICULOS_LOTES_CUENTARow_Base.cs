// <fileinfo name="ARTICULOS_LOTES_CUENTARow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_LOTES_CUENTARow"/> that 
	/// represents a record in the <c>ARTICULOS_LOTES_CUENTA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_LOTES_CUENTARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_LOTES_CUENTARow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _lote;
		private System.DateTime _fecha_fabricacion;
		private bool _fecha_fabricacionNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private decimal _total;
		private bool _totalNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_LOTES_CUENTARow_Base"/> class.
		/// </summary>
		public ARTICULOS_LOTES_CUENTARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_LOTES_CUENTARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.IsFECHA_FABRICACIONNull != original.IsFECHA_FABRICACIONNull) return true;
			if (!this.IsFECHA_FABRICACIONNull && !original.IsFECHA_FABRICACIONNull)
				if (this.FECHA_FABRICACION != original.FECHA_FABRICACION) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsTOTALNull != original.IsTOTALNull) return true;
			if (!this.IsTOTALNull && !original.IsTOTALNull)
				if (this.TOTAL != original.TOTAL) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FABRICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FABRICACION</c> column value.</value>
		public System.DateTime FECHA_FABRICACION
		{
			get
			{
				if(IsFECHA_FABRICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fabricacion;
			}
			set
			{
				_fecha_fabricacionNull = false;
				_fecha_fabricacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FABRICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FABRICACIONNull
		{
			get { return _fecha_fabricacionNull; }
			set { _fecha_fabricacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get
			{
				if(IsTOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total;
			}
			set
			{
				_totalNull = false;
				_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTALNull
		{
			get { return _totalNull; }
			set { _totalNull = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@FECHA_FABRICACION=");
			dynStr.Append(IsFECHA_FABRICACIONNull ? (object)"<NULL>" : FECHA_FABRICACION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(IsTOTALNull ? (object)"<NULL>" : TOTAL);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_LOTES_CUENTARow_Base class
} // End of namespace
