// <fileinfo name="FUNCIONARIOS_VACACIONESRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_VACACIONESRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_VACACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_VACACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_VACACIONESRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private decimal _anho;
		private decimal _dias;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_vencimiento;
		private decimal _dias_utilizados;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_VACACIONESRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_VACACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_VACACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.ANHO != original.ANHO) return true;
			if (this.DIAS != original.DIAS) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.DIAS_UTILIZADOS != original.DIAS_UTILIZADOS) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get { return _anho; }
			set { _anho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS</c> column value.
		/// </summary>
		/// <value>The <c>DIAS</c> column value.</value>
		public decimal DIAS
		{
			get { return _dias; }
			set { _dias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_UTILIZADOS</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_UTILIZADOS</c> column value.</value>
		public decimal DIAS_UTILIZADOS
		{
			get { return _dias_utilizados; }
			set { _dias_utilizados = value; }
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
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(ANHO);
			dynStr.Append("@CBA@DIAS=");
			dynStr.Append(DIAS);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@DIAS_UTILIZADOS=");
			dynStr.Append(DIAS_UTILIZADOS);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_VACACIONESRow_Base class
} // End of namespace
