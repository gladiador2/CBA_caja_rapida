// <fileinfo name="TRAMITES_PROF_RECUSADOSRow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_PROF_RECUSADOSRow"/> that 
	/// represents a record in the <c>TRAMITES_PROF_RECUSADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_PROF_RECUSADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_PROF_RECUSADOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _cargo;
		private string _motivo;
		private string _observaciones;
		private decimal _tramite_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_PROF_RECUSADOSRow_Base"/> class.
		/// </summary>
		public TRAMITES_PROF_RECUSADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_PROF_RECUSADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CARGO != original.CARGO) return true;
			if (this.MOTIVO != original.MOTIVO) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.TRAMITE_ID != original.TRAMITE_ID) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CARGO</c> column value.
		/// </summary>
		/// <value>The <c>CARGO</c> column value.</value>
		public string CARGO
		{
			get { return _cargo; }
			set { _cargo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO</c> column value.
		/// </summary>
		/// <value>The <c>MOTIVO</c> column value.</value>
		public string MOTIVO
		{
			get { return _motivo; }
			set { _motivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_ID</c> column value.</value>
		public decimal TRAMITE_ID
		{
			get { return _tramite_id; }
			set { _tramite_id = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@CARGO=");
			dynStr.Append(CARGO);
			dynStr.Append("@CBA@MOTIVO=");
			dynStr.Append(MOTIVO);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@TRAMITE_ID=");
			dynStr.Append(TRAMITE_ID);
			return dynStr.ToString();
		}
	} // End of TRAMITES_PROF_RECUSADOSRow_Base class
} // End of namespace
