// <fileinfo name="MARCACIONES_ENTRADAS_SALIDASRow_Base.cs">
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
	/// The base class for <see cref="MARCACIONES_ENTRADAS_SALIDASRow"/> that 
	/// represents a record in the <c>MARCACIONES_ENTRADAS_SALIDAS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MARCACIONES_ENTRADAS_SALIDASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MARCACIONES_ENTRADAS_SALIDASRow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private string _tipo_movimiento;
		private System.DateTime _fecha_marcacion;
		private bool _fecha_marcacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MARCACIONES_ENTRADAS_SALIDASRow_Base"/> class.
		/// </summary>
		public MARCACIONES_ENTRADAS_SALIDASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MARCACIONES_ENTRADAS_SALIDASRow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.IsFECHA_MARCACIONNull != original.IsFECHA_MARCACIONNull) return true;
			if (!this.IsFECHA_MARCACIONNull && !original.IsFECHA_MARCACIONNull)
				if (this.FECHA_MARCACION != original.FECHA_MARCACION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MARCACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MARCACION</c> column value.</value>
		public System.DateTime FECHA_MARCACION
		{
			get
			{
				if(IsFECHA_MARCACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_marcacion;
			}
			set
			{
				_fecha_marcacionNull = false;
				_fecha_marcacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MARCACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MARCACIONNull
		{
			get { return _fecha_marcacionNull; }
			set { _fecha_marcacionNull = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@FECHA_MARCACION=");
			dynStr.Append(IsFECHA_MARCACIONNull ? (object)"<NULL>" : FECHA_MARCACION);
			return dynStr.ToString();
		}
	} // End of MARCACIONES_ENTRADAS_SALIDASRow_Base class
} // End of namespace
