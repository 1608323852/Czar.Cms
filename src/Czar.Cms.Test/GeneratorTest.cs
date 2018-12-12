
using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Czar.Cms.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Czar.Cms.Test
{
    /// <summary>
    /// yilezhu
    /// 2018.12.12
    /// ���Դ���������
    /// ��ʱֻʵ����SqlServer��ʵ���������
    /// </summary>
    public class GeneratorTest
    {
        [Fact]
        public void GeneratorModelForSqlServer()
        {
            var serviceProvider= BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateModelCodesFromDatabase();
            Assert.Equal(0,0);

        }

        /// <summary>
        /// ��������ע��������Ȼ�������
        /// </summary>
        /// <returns></returns>
        public IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();

            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=.;Initial Catalog=CzarCms;User ID=sa;Password=1;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";
                options.DbType = DatabaseType.SqlServer.ToString();//���ݿ�������SqlServer,�����������Ͳ���ö��DatabaseType
                options.Author = "yilezhu";//��������
                options.OutputPath = @"E:\workspace\vs2017\Czar.Cms\src\Czar.Cms.Models";//ʵ��ģ�����·����Ϊ����Ĭ��Ϊ��ǰ�������е�·��
                options.ModelsNamespace = "Czar.Cms.Models";//ʵ�������ռ�
            });
            services.AddSingleton<CodeGenerator>();//ע��Model����������
            return services.BuildServiceProvider(); //���������ṩ����
        }
    }
}
