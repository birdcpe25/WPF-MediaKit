sampler2D input : register(s0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color;
	float2 pColor;
	pColor.x = uv.x / 2;
	pColor.y = uv.y;

	color = tex2D(input , pColor.xy);

	float4 mapColor;
	float2 pMapColor;
	pMapColor.x = 0.5 + (uv.x / 2);
	pMapColor.y = uv.y;
	mapColor = tex2D(input, pMapColor.xy);

	color.a = mapColor.r;

	return color;
}