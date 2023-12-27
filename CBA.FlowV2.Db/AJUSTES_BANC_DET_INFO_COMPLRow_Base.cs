// <fileinfo name="AJUSTES_BANC_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="AJUSTES_BANC_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>AJUSTES_BANC_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="AJUSTES_BANC_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AJUSTES_BANC_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ajuste_bancario_id;
		private decimal _monto;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido_texto;

		/// <summary>
		/// Initializes a new instance of the <see cref="AJUSTES_BANC_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public AJUSTES_BANC_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(AJUSTES_BANC_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.AJUSTE_BANCARIO_ID != original.AJUSTE_BANCARIO_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_TEXTO != original.TEXTO_PREDEFINIDO_TEXTO) return true;
			
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
		/// Gets or sets the <c>AJUSTE_BANCARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>AJUSTE_BANCARIO_ID</c> column value.</value>
		public decimal AJUSTE_BANCARIO_ID
		{
			get { return _ajuste_bancario_id; }
			set { _ajuste_bancario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.</value>
		public string TEXTO_PREDEFINIDO_TEXTO
		{
			get { return _texto_predefinido_texto; }
			set { _texto_predefinido_texto = value; }
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
			dynStr.Append("@CBA@AJUSTE_BANCARIO_ID=");
			dynStr.Append(AJUSTE_BANCARIO_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_TEXTO=");
			dynStr.Append(TEXTO_PREDEFINIDO_TEXTO);
			return dynStr.ToString();
		}
	} // End of AJUSTES_BANC_DET_INFO_COMPLRow_Base class
} // End of namespace
