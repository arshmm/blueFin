// Shortens a positive number to K / M / B / T, or returns null if it's under 1,000.
const compact = (number: number): string | null => {
  if (number >= 1_000_000_000_000) {
    return (number / 1_000_000_000_000).toFixed(1) + "T";
  } else if (number >= 1_000_000_000) {
    return (number / 1_000_000_000).toFixed(1) + "B";
  } else if (number >= 1_000_000) {
    return (number / 1_000_000).toFixed(1) + "M";
  } else if (number >= 1_000) {
    return (number / 1_000).toFixed(1) + "K";
  }
  return null;
};

export const formatLargeMonetaryNumber = (number: number): string => {
  if (!Number.isFinite(number)) {
    return "N/A";
  }
  if (number < 0) {
    return "-" + formatLargeMonetaryNumber(-1 * number);
  }
  return "$" + (compact(number) ?? number.toFixed(2));
};

export const formatLargeNonMonetaryNumber = (number: number): string => {
  if (!Number.isFinite(number)) {
    return "N/A";
  }
  if (number < 0) {
    return "-" + formatLargeNonMonetaryNumber(-1 * number);
  }
  return compact(number) ?? String(Math.round(number * 100) / 100);
};

export const formatRatio = (ratio: number): string => {
  if (!Number.isFinite(ratio)) {
    return "N/A";
  }
  return ratio.toFixed(2);
};
