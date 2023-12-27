// <fileinfo name="DETALLES_PERSONALIZADOS_HIST_DRow_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> that 
	/// represents a record in the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOS_HIST_DRow_Base
	{
		private decimal _id;
		private decimal _detalle_personalizado_hist_id;
		private decimal _valor_numero;
		private bool _valor_numeroNull = true;
		private System.DateTime _valor_fecha;
		private bool _valor_fechaNull = true;
		private string _valor_texto;
		private decimal _orden;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HIST_DRow_Base"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOS_HIST_DRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DETALLES_PERSONALIZADOS_HIST_DRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DETALLE_PERSONALIZADO_HIST_ID != original.DETALLE_PERSONALIZADO_HIST_ID) return true;
			if (this.IsVALOR_NUMERONull != original.IsVALOR_NUMERONull) return true;
			if (!this.IsVALOR_NUMERONull && !original.IsVALOR_NUMERONull)
				if (this.VALOR_NUMERO != original.VALOR_NUMERO) return true;
			if (this.IsVALOR_FECHANull != original.IsVALOR_FECHANull) return true;
			if (!this.IsVALOR_FECHANull && !original.IsVALOR_FECHANull)
				if (this.VALOR_FECHA != original.VALOR_FECHA) return true;
			if (this.VALOR_TEXTO != original.VALOR_TEXTO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.
		/// </summary>
		/// <value>The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</value>
		public decimal DETALLE_PERSONALIZADO_HIST_ID
		{
			get { return _detalle_personalizado_hist_id; }
			set { _detalle_personalizado_hist_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NUMERO</c> column value.</value>
		public decimal VALOR_NUMERO
		{
			get
			{
				if(IsVALOR_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_numero;
			}
			set
			{
				_valor_numeroNull = false;
				_valor_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_NUMERONull
		{
			get { return _valor_numeroNull; }
			set { _valor_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_FECHA</c> column value.</value>
		public System.DateTime VALOR_FECHA
		{
			get
			{
				if(IsVALOR_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_fecha;
			}
			set
			{
				_valor_fechaNull = false;
				_valor_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_FECHANull
		{
			get { return _valor_fechaNull; }
			set { _valor_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_TEXTO</c> column value.</value>
		public string VALOR_TEXTO
		{
			get { return _valor_texto; }
			set { _valor_texto = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@DETALLE_PERSONALIZADO_HIST_ID=");
			dynStr.Append(DETALLE_PERSONALIZADO_HIST_ID);
			dynStr.Append("@CBA@VALOR_NUMERO=");
			dynStr.Append(IsVALOR_NUMERONull ? (object)"<NULL>" : VALOR_NUMERO);
			dynStr.Append("@CBA@VALOR_FECHA=");
			dynStr.Append(IsVALOR_FECHANull ? (object)"<NULL>" : VALOR_FECHA);
			dynStr.Append("@CBA@VALOR_TEXTO=");
			dynStr.Append(VALOR_TEXTO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			return dynStr.ToString();
		}
	} // End of DETALLES_PERSONALIZADOS_HIST_DRow_Base class
} // End of namespace
