using Bunit;
using Microsoft.Extensions.DependencyInjection;
using DependentVariablesExample.Pages;
using DependentVariablesExample.IGNW;

namespace TestDependentVariablesExample
{
	[Collection("DependentVariablesExample")]
	public class TestMaster_View
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbComboModule),
				typeof(IgbGridModule),
				typeof(IgbDataGridToolbarModule));
			ctx.Services.AddScoped<IIGNWService>(sp => new MockIGNWService());
			var componentUnderTest = ctx.RenderComponent<Master_View>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
