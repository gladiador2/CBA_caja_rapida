// <fileinfo name="ENCUESTAS_DETALLERow_Base.cs">
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
	/// The base class for <see cref="ENCUESTAS_DETALLERow"/> that 
	/// represents a record in the <c>ENCUESTAS_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENCUESTAS_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENCUESTAS_DETALLERow_Base
	{
		private decimal _id;
		private decimal _encuestas_pregunta_id;
		private decimal _encuestas_respuesta_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _texto;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_DETALLERow_Base"/> class.
		/// </summary>
		public ENCUESTAS_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENCUESTAS_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENCUESTAS_PREGUNTA_ID != original.ENCUESTAS_PREGUNTA_ID) return true;
			if (this.ENCUESTAS_RESPUESTA_ID != original.ENCUESTAS_RESPUESTA_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.TEXTO != original.TEXTO) return true;
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
		/// Gets or sets the <c>ENCUESTAS_PREGUNTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENCUESTAS_PREGUNTA_ID</c> column value.</value>
		public decimal ENCUESTAS_PREGUNTA_ID
		{
			get { return _encuestas_pregunta_id; }
			set { _encuestas_pregunta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENCUESTAS_RESPUESTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENCUESTAS_RESPUESTA_ID</c> column value.</value>
		public decimal ENCUESTAS_RESPUESTA_ID
		{
			get { return _encuestas_respuesta_id; }
			set { _encuestas_respuesta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
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
		/// Gets or sets the <c>TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
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
			dynStr.Append("@CBA@ENCUESTAS_PREGUNTA_ID=");
			dynStr.Append(ENCUESTAS_PREGUNTA_ID);
			dynStr.Append("@CBA@ENCUESTAS_RESPUESTA_ID=");
			dynStr.Append(ENCUESTAS_RESPUESTA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ENCUESTAS_DETALLERow_Base class
} // End of namespace
