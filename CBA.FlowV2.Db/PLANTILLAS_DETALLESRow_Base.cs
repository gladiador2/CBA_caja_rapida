// <fileinfo name="PLANTILLAS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="PLANTILLAS_DETALLESRow"/> that 
	/// represents a record in the <c>PLANTILLAS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANTILLAS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANTILLAS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _plantilla_id;
		private string _sql;
		private string _parametro;
		private decimal _longitud_minima;
		private bool _longitud_minimaNull = true;
		private string _caracter_relleno;
		private string _tabla_id;
		private string _pregunta;
		private string _tipo_dato;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANTILLAS_DETALLESRow_Base"/> class.
		/// </summary>
		public PLANTILLAS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANTILLAS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANTILLA_ID != original.PLANTILLA_ID) return true;
			if (this.SQL != original.SQL) return true;
			if (this.PARAMETRO != original.PARAMETRO) return true;
			if (this.IsLONGITUD_MINIMANull != original.IsLONGITUD_MINIMANull) return true;
			if (!this.IsLONGITUD_MINIMANull && !original.IsLONGITUD_MINIMANull)
				if (this.LONGITUD_MINIMA != original.LONGITUD_MINIMA) return true;
			if (this.CARACTER_RELLENO != original.CARACTER_RELLENO) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.PREGUNTA != original.PREGUNTA) return true;
			if (this.TIPO_DATO != original.TIPO_DATO) return true;
			
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
		/// Gets or sets the <c>PLANTILLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANTILLA_ID</c> column value.</value>
		public decimal PLANTILLA_ID
		{
			get { return _plantilla_id; }
			set { _plantilla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SQL</c> column value.</value>
		public string SQL
		{
			get { return _sql; }
			set { _sql = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PARAMETRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PARAMETRO</c> column value.</value>
		public string PARAMETRO
		{
			get { return _parametro; }
			set { _parametro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD_MINIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD_MINIMA</c> column value.</value>
		public decimal LONGITUD_MINIMA
		{
			get
			{
				if(IsLONGITUD_MINIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud_minima;
			}
			set
			{
				_longitud_minimaNull = false;
				_longitud_minima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD_MINIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD_MINIMANull
		{
			get { return _longitud_minimaNull; }
			set { _longitud_minimaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CARACTER_RELLENO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CARACTER_RELLENO</c> column value.</value>
		public string CARACTER_RELLENO
		{
			get { return _caracter_relleno; }
			set { _caracter_relleno = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREGUNTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREGUNTA</c> column value.</value>
		public string PREGUNTA
		{
			get { return _pregunta; }
			set { _pregunta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DATO</c> column value.</value>
		public string TIPO_DATO
		{
			get { return _tipo_dato; }
			set { _tipo_dato = value; }
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
			dynStr.Append("@CBA@PLANTILLA_ID=");
			dynStr.Append(PLANTILLA_ID);
			dynStr.Append("@CBA@SQL=");
			dynStr.Append(SQL);
			dynStr.Append("@CBA@PARAMETRO=");
			dynStr.Append(PARAMETRO);
			dynStr.Append("@CBA@LONGITUD_MINIMA=");
			dynStr.Append(IsLONGITUD_MINIMANull ? (object)"<NULL>" : LONGITUD_MINIMA);
			dynStr.Append("@CBA@CARACTER_RELLENO=");
			dynStr.Append(CARACTER_RELLENO);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@PREGUNTA=");
			dynStr.Append(PREGUNTA);
			dynStr.Append("@CBA@TIPO_DATO=");
			dynStr.Append(TIPO_DATO);
			return dynStr.ToString();
		}
	} // End of PLANTILLAS_DETALLESRow_Base class
} // End of namespace
