using System.Text.RegularExpressions;

namespace Agenda.Model.Utils
{
    public static class Helper
    {
        private static readonly Dictionary<int, string> Ddds = new()
{
    { 11, "São Paulo" },
    { 12, "São Paulo" },
    { 13, "São Paulo" },
    { 14, "São Paulo" },
    { 15, "São Paulo" },
    { 16, "São Paulo" },
    { 17, "São Paulo" },
    { 18, "São Paulo" },
    { 19, "São Paulo" },
    { 21, "Rio de Janeiro" },
    { 22, "Rio de Janeiro" },
    { 24, "Rio de Janeiro" },
    { 31, "Minas Gerais" },
    { 32, "Minas Gerais" },
    { 33, "Minas Gerais" },
    { 34, "Minas Gerais" },
    { 35, "Minas Gerais" },
    { 37, "Minas Gerais" },
    { 41, "Paraná" },
    { 42, "Paraná" },
    { 43, "Paraná" },
    { 44, "Paraná" },
    { 45, "Paraná" },
    { 46, "Paraná" },
    { 47, "Santa Catarina" },
    { 48, "Santa Catarina" },
    { 49, "Santa Catarina" },
    { 51, "Rio Grande do Sul" },
    { 53, "Rio Grande do Sul" },
    { 54, "Rio Grande do Sul" },
    { 55, "Rio Grande do Sul" },
    { 61, "Distrito Federal" },
    { 62, "Goiás" },
    { 63, "Tocantins" },
    { 64, "Maranhão" },
    { 65, "Mato Grosso" },
    { 66, "Mato Grosso" },
    { 67, "Mato Grosso do Sul" },
    { 68, "Acre" },
    { 69, "Amapá" },
    { 71, "Bahia" },
    { 73, "Bahia" },
    { 74, "Bahia" },
    { 75, "Bahia" },
    { 77, "Bahia" },
    { 79, "Sergipe" },
    { 81, "Pernambuco" },
    { 82, "Alagoas" },
    { 83, "Paraíba" },
    { 84, "Rio Grande do Norte" },
    { 85, "Ceará" },
    { 86, "Piauí" },
    { 87, "Pernambuco" },
    { 88, "Ceará" },
    { 89, "Piauí" },
    { 91, "Pará" },
    { 92, "Amazonas" },
    { 93, "Pará" },
    { 94, "Pará" },
    { 95, "Roraima" },
    { 96, "Amapá" },
    { 97, "Amazonas" },
    { 98, "Maranhão" },
    { 99, "Maranhão" }
};

        private const string EmailRegexPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private const string TelefoneRegexPattern = @"^\d{4}-?\d{4}$"; // Fixo (sem DDD, apenas 8 dígitos)
        private const string CelularRegexPattern = @"^9\d{4}-?\d{4}$"; // Celular (sem DDD, apenas 8 dígitos começando com 9)
        public static string ObterRegiaoPorDdd(int ddd)
        {
            return Ddds.TryGetValue(ddd, out var regiao) ? regiao : null; // Retorna null em vez de mensagem
        }

        public static bool ValidarDddComRegiao(int ddd, string regiao)
        {
            return Ddds.TryGetValue(ddd, out var regiaoCorrespondente)
                && string.Equals(regiaoCorrespondente, regiao, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ValidarEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EmailRegexPattern);
        }

        public static bool ValidarTelefone(string telefone)
        {
            return !string.IsNullOrWhiteSpace(telefone) && Regex.IsMatch(telefone, TelefoneRegexPattern);
        }
        public static bool ValidarCelular(string celular)
        {
            return !string.IsNullOrWhiteSpace(celular) && Regex.IsMatch(celular, CelularRegexPattern);
        }
        public static bool ValidarDdd(int ddd)
        {
            return Ddds.ContainsKey(ddd); // Verifica se o DDD está presente na lista
        }
    }
}
